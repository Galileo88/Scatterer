//------------------------------------------------------------------------------
// <auto-generated>

using UnityEngine;
using System.Collections;
using System.IO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using KSP.IO;

namespace scatterer
{
	public class cameraHDRTonemapping: MonoBehaviour
	{	
		Material toneMappingMaterial;
		float exposure=2.5f;
		Core m_core;
		
		void Start()
		{	
			toneMappingMaterial = new Material (ShaderTool.GetMatFromShader2 ("CompiledToneMapper.shader"));
		}
		
		public void setExposure(float inExposure)
		{
			exposure = inExposure;
		}
		
//		public void settings(float inExposure, Material inMat)
//		{
//			exposure = inExposure;
//			toneMappingMaterial=inMat;
//		}
		
		
		void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			//insert bloom here
			
			//tone mapping: HDR -> LDR
			toneMappingMaterial.SetFloat("_ExposureAdjustment", exposure);
			Graphics.Blit(source, destination, toneMappingMaterial, 8); //tonemapping, 8 is choosing the photographic preset/pass
		}		
	}
}