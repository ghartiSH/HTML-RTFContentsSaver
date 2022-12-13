using CsvHelper.Configuration;

namespace FileSaver.Models
{
    public class CSVDataMap: ClassMap<CSVData>
    {
        public CSVDataMap()
        {
            Map(m => m.Superclass).Name("Superclass(es)");
            Map(m => m.Label).Name("http://www.w3.org/2000/01/rdf-schema#label");
            Map(m => m.IRI).Name("IRI");
            Map(m => m.Type).Name("Type");
            Map(m => m.Sali_appealsTo).Name("http://lmss.sali.org/RCx3rNyJdykIdu45Cr4ajaK");
            Map(m => m.Sali_hasExpense).Name("http://lmss.sali.org/RDg3svGlPQWSeM8eDKzJTSf");
            Map(m => m.Sali_filed).Name("http://lmss.sali.org/RDkNxLSVfcWlNUKatMJwnMt");
            Map(m => m.Sali_seeksToAchieve).Name("http://lmss.sali.org/RN3mWlXZUAt07dYsu6tls2");
            Map(m => m.Sali_workedFor).Name("http://lmss.sali.org/RZSnKehA643O8824iC320g");
            Map(m => m.Sali_cited).Name("http://lmss.sali.org/RdpSPh3bFHYrQ3vYPDwJYB");
            Map(m => m.Sali_participatedIn).Name("http://lmss.sali.org/RznfymBGs7WesrwWNzQLov");
            Map(m => m.LocatedIn).Name("http://www.w3.org/2000/01/rdf-schema#locatedIn");
            Map(m => m.SeeAlso).Name("http://www.w3.org/2000/01/rdf-schema#seeAlso");
            Map(m => m.IsAuthor).Name("http://www.w3.org/2002/07/owl#isAuthor");
            Map(m => m.SameAs).Name("http://www.w3.org/2002/07/owl#sameAs"); 
            Map(m => m.Before).Name("http://www.w3.org/2006/time#before");
            Map(m => m.Sali_seealso).Name("http://lmss.sali.org/R9v40mW8ZGVrxMxI6cqO6uA");
            Map(m => m.legacyIdentifier).Name("http://lmss.sali.org/legacyIdentifier");
            Map(m => m.Description).Name("http://purl.org/dc/elements/1.1/description");
            Map(m => m.Identifier).Name("http://purl.org/dc/elements/1.1/identifier");
            Map(m => m.LinkFirst).Name("http://webprotege.stanford.edu/RBwBJ2lKdRgVYPkQmoJN1pD");
            Map(m => m.LinkSecond).Name("http://webprotege.stanford.edu/RCAWR19VGcj184M2SBAaeoj");
            Map(m => m.HasRelatedSynonym).Name("http://www.geneontology.org/formats/oboInOwl#hasRelatedSynonym");
            Map(m => m.Comment).Name("http://www.w3.org/2000/01/rdf-schema#comment");
            Map(m => m.IsDefinedBy).Name("http://www.w3.org/2000/01/rdf-schema#isDefinedBy");
            Map(m => m.Deprecated).Name("http://www.w3.org/2002/07/owl#deprecated");
            Map(m => m.InverseOf).Name("http://www.w3.org/2002/07/owl#inverseOf");
            Map(m => m.AltLabel).Name("http://www.w3.org/2004/02/skos/core#altLabel");
            Map(m => m.Definition).Name("http://www.w3.org/2004/02/skos/core#definition");
            Map(m => m.HiddenLabel).Name("http://www.w3.org/2004/02/skos/core#hiddenLabel");
            Map(m => m.PrefLabel).Name("http://www.w3.org/2004/02/skos/core#prefLabel");
        }
    }
}
