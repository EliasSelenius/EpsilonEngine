﻿
#version 440 core
#define ShaderType



#ifdef VertexShader

	uniform mat4 model;
	uniform mat4 view;
	uniform mat4 projection;

	layout (location = 0) in vec3 aPos;
	layout (location = 1) in vec3 aNormal;

	out vec3 FragPos;
	out vec3 Normal;

	void main() {
		gl_Position = projection * view * model * vec4(aPos, 1.0f);
		FragPos = vec3(model * vec4(aPos, 1.0));
		Normal = mat3(transpose(inverse(model))) * aNormal;
		//Normal = aNormal;
	}
#endif



#ifdef FragmentShader


	uniform vec3 objectColor;
	uniform vec3 lightColor;
	uniform vec3 lightPos;
	uniform vec3 viewPos;

	out vec4 FragColor;

	in vec3 Normal;
	in vec3 FragPos;

	void main() {

		// calc Ambient light
		float ambientStrength = 0.1;
		vec3 ambient = ambientStrength * lightColor;

		// calc Diffuse light
		//// NOTE: naively expecting Normal to alredy be normalized
		vec3 norm = normalize(Normal);
		vec3 lightDir = normalize(lightPos - FragPos);
		float diff = max(dot(norm, lightDir), 0.0);
		vec3 diffuse = diff * lightColor;

		// calc specular light
		float specularStrength = 0.5;
		vec3 viewDir = normalize(viewPos - FragPos);
		vec3 reflectDir = reflect(-lightDir, norm);
		float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32);
		vec3 specular = specularStrength * spec * lightColor;
		
		vec3 result = (ambient + diffuse + specular) * objectColor;
		FragColor = vec4(result, 1.0);
	}
#endif