using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BreastPhysicsController.Compatibility
{
    [XmlRoot("XMLDynamicBoneParameter")]
    public class XMLDynamicBoneParameter
    {
        [XmlElement("Version")]
        public string Version = "1";
        private static readonly List<string> partNames = new List<string> { "Bust01", "Bust02", "Bust03" };
        [XmlArray("ParameterSets")]
        [XmlArrayItem("ParameterSet")]
        public List<XMLParamSet> parameterSets;

        public XMLParamSet GetParameterSet(string partName)
        {
            foreach (XMLParamSet set in parameterSets)
            {
                if (set.PartName == partName) return set;
            }
            return null;
        }

        public bool Deserialize(StreamReader reader)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XMLDynamicBoneParameter));
            XMLDynamicBoneParameter xmlDynamicBoneParam;
            try
            {
                xmlDynamicBoneParam = serializer.Deserialize(reader) as XMLDynamicBoneParameter;
            }
            catch
            {
                return false;
            }
            if (xmlDynamicBoneParam == null) return false;

            Version = xmlDynamicBoneParam.Version;
            parameterSets = xmlDynamicBoneParam.parameterSets;
            return true;
        }

        public void CopyParamsTo(ParamBustCustom target)
        {
            foreach (XMLParamSet set in parameterSets)
            {
                switch (set.PartName)
                {
                    case "Bust01":
                        set.CopyParameterTo(target.paramBones[ParamBustCustom.Bones[0]]);
                        break;
                    case "Bust02":
                        set.CopyParameterTo(target.paramBones[ParamBustCustom.Bones[1]]);
                        break;
                    case "Bust03":
                        set.CopyParameterTo(target.paramBones[ParamBustCustom.Bones[2]]);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
