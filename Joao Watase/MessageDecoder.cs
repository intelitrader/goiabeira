using QuickFix;
using QuickFix.DataDictionary;
using QuickFix.Fields;
using System.Text;

namespace QuickfixAcceptor
{
    public static class MessageDecoder
    {
        public static string Decode(Message message)
        {
            var dataDictionary = new DataDictionary(@"dictionary\FIX44EntrypointGatewayEquities.xml");
            var stringBuilder = new StringBuilder("Fix {");
            var msgType = message.Header.GetString(Tags.MsgType);
            DecodeFieldMap(dataDictionary, stringBuilder, msgType, message.Header);
            DecodeFieldMap(dataDictionary, stringBuilder, msgType, message);
            DecodeFieldMap(dataDictionary, stringBuilder, msgType, message.Trailer);
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }
        public static void DecodeFieldMap(DataDictionary dd, StringBuilder str, string msgType, FieldMap fieldMap)
        {
            
            foreach (var kvp in fieldMap)
            {
                if (dd.IsGroup(msgType, kvp.Key)) continue;
                var field = dd.FieldsByTag[kvp.Key];
                var value = fieldMap.GetString(field.Tag);
                if (dd.FieldHasValue(field.Tag, value))
                {
                    value = $"{field.EnumDict[value]} ({value})";
                }
                str.AppendFormat("{1} = {2}; ", field.Name, value);
            }
            
        }
    }
}