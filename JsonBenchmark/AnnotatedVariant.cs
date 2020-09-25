using System;
using System.Collections.Generic;
using System.Text;

namespace JsonBenchmark
{
    public class AnnotatedVariant
    {
        public sealed class AnnotatedTranscript:IJsonSerializer
        {
            public static readonly string[] ConsequenceSet =
            {
                "coding_sequence_variant", "downstream_gene_variant", "five_prime_duplicated_transcript",
                "five_prime_UTR_variant", "frameshift_variant", "incomplete_terminal_codon_variant", "start_lost",
                "intron_variant", "missense_variant", "mature_miRNA_variant", "protein_altering_variant", "splice_region_variant",
                "stop_lost", "stop_gained", "stop_retained", "synonymous_variant","transcript_variant"
            };
            public string Id{get;}
            public string[] Consequences{get;}
            private static readonly Random _random = new Random();

            private AnnotatedTranscript(string id, string[] consequences)
            {
                Id = id;
                Consequences = consequences;
            }

            public static AnnotatedTranscript Create()
            {
                var x = _random.Next(100, 10000);
                var id = $"TRAN_{x:0000000}";
                var consequences = new string[_random.Next(1, 10)];
                for (int i = 0; i < consequences.Length; i++)
                {
                    var j = _random.Next(0, ConsequenceSet.Length - 1);
                    consequences[i] = ConsequenceSet[j];
                }

                return new AnnotatedTranscript(id, ConsequenceSet);
            }

            public void SerializeJson(StringBuilder sb)
            {
                sb.Append(NirvanaJsonObject.OpenBrace);
                var jsonObject = new NirvanaJsonObject(sb);
                jsonObject.AddStringValue("Id", Id);
                jsonObject.AddStringValues("Consequences", Consequences);
                sb.Append(NirvanaJsonObject.CloseBrace);
            }
        }

        public static readonly string[] ChromNames = {"chr1", "chr2","chr3", "chr4","chr5", "chr6","chr7", "chr8","chr9", "chr10","chr11", "chr12"};

        public static readonly string[] Alleles = {"A", "C", "G", "T", "AA", "AC", "AT", "AG", "CC", "CG", "CT", "CA", "GA", "GC", "GT", "GG","TA", "TC", "TT", "TG"};
        public static readonly string[] PathogenicitySet = { "benign", "likely benign", "likely pathogenic", "pathogenic", "unknown"};
        private static Random _random = new Random();
        
        public string Chromosome {get;}
        public int Position {get;}
        public string RefAllele {get;}
        public string AltAllele{get;}

        public AnnotatedTranscript[] Transcripts{get;}

        public double AlleleFrequency{get;}
        public string Pathogenicity {get;}
        public int[] PubmedIds {get;}

        private AnnotatedVariant(string chromosome, int position, string refAllele, string altAllele,
            AnnotatedTranscript[] transcripts,
            double alleleFrequency, string pathogenicity, int[] pubmedIds)
        {
            Chromosome = chromosome;
            Position = position;
            RefAllele = refAllele;
            AltAllele = altAllele;
            Transcripts = transcripts;
            AlleleFrequency = alleleFrequency;
            Pathogenicity = pathogenicity;
            PubmedIds = pubmedIds;
        }

        public static AnnotatedVariant Create()
        {
            var chrom = ChromNames[_random.Next(0, ChromNames.Length - 1)];
            var position = _random.Next(1_000, 250_000_000);
            var refAllele = Alleles[_random.Next(0, Alleles.Length - 1)];
            var altAllele = Alleles[_random.Next(0, Alleles.Length - 1)];
            var alleleFrequency = _random.Next(0,1_000_000)*1.0/1_000_000;
            var pathogenicity = PathogenicitySet[_random.Next(0, PathogenicitySet.Length - 1)];
            
            var transcripts = new AnnotatedTranscript[_random.Next(1,15)];
            for (int i = 0; i < transcripts.Length; i++)
            {
                transcripts[i]= AnnotatedTranscript.Create();
            }

            var pubmedIds = new int[_random.Next(2,20)];
            for (int i = 0; i < pubmedIds.Length; i++)
            {
                pubmedIds[i] = _random.Next(10_000, 100_000);
            }
            return new AnnotatedVariant(chrom, position, refAllele, altAllele, transcripts, alleleFrequency, pathogenicity, pubmedIds);
        }

        public string SerializeJson()
        {
            var sb = new StringBuilder();
            var jsonObject = new NirvanaJsonObject(sb);
            sb.Append(NirvanaJsonObject.OpenBrace);
            jsonObject.AddStringValue("Chromosome", Chromosome);
            jsonObject.AddIntValue("Position", Position);
            jsonObject.AddStringValue("RefAllele", RefAllele);
            jsonObject.AddStringValue("AltAllele", AltAllele);
            jsonObject.AddObjectValues("Transcripts", Transcripts);
            jsonObject.AddDoubleValue("AlleleFrequency", AlleleFrequency,"0.######");
            jsonObject.AddStringValue("Pathogenicity", Pathogenicity);
            jsonObject.AddIntValues("PubmedIds", PubmedIds);
            sb.Append(NirvanaJsonObject.CloseBrace);

            return sb.ToString();
        }
    }
}