namespace JsonBenchmark
{
    public static class Utilities
    {
        public static AnnotatedVariant[] CreateAnnotatedVariants(int count)
        {
            var annoVariants = new AnnotatedVariant[count];
            for (int i = 0; i < count; i++)
            {
                annoVariants[i]= AnnotatedVariant.Create();
            }

            return annoVariants;
        }
    }
}