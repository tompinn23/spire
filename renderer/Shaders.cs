using System;
using System.Collections.Generic;
using System.IO;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Platform.Windows;
using All = OpenTK.Graphics.OpenGL4.All;

namespace spire.renderer {
    public class Shaders {

        
        public class Shader {
            public readonly int handle;
            private readonly Dictionary<string, int> uniformLocs;

            private Shader(string vertexSource, string fragSource) {
                int vertexShader = GL.CreateShader(ShaderType.VertexShader);
                GL.ShaderSource(vertexShader, vertexSource);
                CompileShader(vertexShader);

                int fragShader = GL.CreateShader(ShaderType.FragmentShader);
                GL.ShaderSource(fragShader, fragSource);
                CompileShader(fragShader);
                
                handle = GL.CreateProgram();
                GL.AttachShader(handle, vertexShader);
                GL.AttachShader(handle,fragShader);
                GL.LinkProgram(handle);
                GL.GetProgram(handle, GetProgramParameterName.LinkStatus, out var code);
                if (code != (int) All.True) {
                    throw new Exception($"Error occured whilst linking program: {handle}");
                }
                GL.DetachShader(handle, vertexShader);
                GL.DetachShader(handle, fragShader);
                GL.DeleteShader(fragShader);
                GL.DeleteShader(vertexShader);
                GL.GetProgram(handle, GetProgramParameterName.ActiveUniforms, out var numberOfUniforms);
                uniformLocs = new Dictionary<string, int>();
                for (var i = 0; i < numberOfUniforms; i++) {
                    var key = GL.GetActiveUniform(handle, i, out _, out _);
                    var location = GL.GetUniformLocation(handle, key);
                    uniformLocs.Add(key, location);
                }
            }
            
            public static Shader create(string vSource, string fSource) {
                return new Shader(vSource, fSource);
            }

            public static Shader createFile(string vertexPath, string fragPath) {
                return new Shader(File.ReadAllText(vertexPath), File.ReadAllText(fragPath));
            }

            public void Use() {
                GL.UseProgram(handle);
            }

            public void SetInt(string name, int data) {
                GL.UseProgram(handle);
                GL.Uniform1(uniformLocs[name], data);
            }

            public void SetFloat(string name, float data) {
                GL.UseProgram(handle);
                GL.Uniform1(uniformLocs[name], data);
            }

            public void SetMat4(string name, Matrix4 data) {
                GL.UseProgram(handle);
                GL.UniformMatrix4(uniformLocs[name], true, ref data);
            }

            public void SetVector3(string name, Vector3 data) {
                GL.UseProgram(handle);
                GL.Uniform3(uniformLocs[name], data);
            }

            private static void CompileShader(int shader) {
                GL.CompileShader(shader);
                GL.GetShader(shader, ShaderParameter.CompileStatus, out var code);
                if (code != (int) All.True) {
                    var infoLog = GL.GetShaderInfoLog(shader);
                    throw new Exception($"Error occured whilst compiling Shader: {shader}.\n\n {infoLog}");
                }
            }
        }
    }
}