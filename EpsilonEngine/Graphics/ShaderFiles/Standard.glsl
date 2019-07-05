
#version 440 core
#define ShaderType



#ifdef VertexShader

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

layout (location = 0) in vec3 vPos;

void main() {
	gl_Position = projection * view * model * vec4(vPos, 1.0f);
}
#endif

#ifdef FragmentShader
out vec4 fragColor;
void main() {
	fragColor = vec4(1.0f, 0.0f, 0.0f, 1.0f);
}
#endif