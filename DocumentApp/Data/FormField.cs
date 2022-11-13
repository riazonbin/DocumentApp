namespace DocumentApp.Data
{
    public class FormField
    {
        public FormField(string fieldName, string fieldValue)
        {
            FieldName = fieldName;
            FieldValue = fieldValue;
        }

        public string FieldName { get; set; }
        public string FieldValue { get; set; }



    }
}
