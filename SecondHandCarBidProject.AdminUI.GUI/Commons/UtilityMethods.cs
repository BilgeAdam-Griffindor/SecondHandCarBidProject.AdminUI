using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SecondHandCarBidProject.AdminUI.GUI.Commons
{
    public static class UtilityMethods
    {
        public static List<byte[]> ToListByteArray(this List<IFormFile> formFiles)
        {
            return formFiles.Select(file => file.ToByteArray()).ToList();
        }

        public static byte[] ToByteArray(this IFormFile formFile)
        {
            byte[] bytes;

            using (MemoryStream ms = new MemoryStream())
            {
                formFile.CopyTo(ms);
                bytes = ms.ToArray();
            }

            return bytes;
        }
    }
}
