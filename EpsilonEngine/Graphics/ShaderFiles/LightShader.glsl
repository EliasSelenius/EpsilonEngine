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

	struct Material {
		vec3 ambient;
		vec3 diffuse;
		vec3 specular;
		float shininess;
	};

	struct Light {
		vec3 position;

		vec3 ambient;
		vec3 diffuse;
		vec3 specular;
	};

	uniform Light light;
	uniform Material material;
	uniform vec3 viewPos;

	out vec4 FragColor;

	in vec3 Normal;
	in vec3 FragPos;

	void main() {

		// calc Ambient light
		vec3 ambient = light.ambient * material.ambient;

		// calc Diffuse light
		vec3 norm = normalize(Normal);
		vec3 lightDir = normalize(light.position - FragPos);
		float diff = max(dot(norm, lightDir), 0.0);
		vec3 diffuse = light.diffuse * (diff * material.diffuse);

		// calc specular light
		vec3 viewDir = normalize(viewPos - FragPos);
		vec3 reflectDir = reflect(-lightDir, norm);
		float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
		vec3 specular = light.specular * (spec * material.specular);
		
		vec3 result = ambient + diffuse + specular;
		FragColor = vec4(result, 1.0);
	}
#endif