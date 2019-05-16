using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDS.RDF;
using VDS.RDF.Query;

namespace sprql
{
    class Program
    {
        static void Main(string[] args)
        {
            SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");

            //Make a SELECT query against the Endpoint
            SparqlResultSet results = endpoint.QueryWithResultSet("PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>\n" +
"PREFIX db: <http://dbpedia.org/ontology/>\n" +
"PREFIX prop: <http://dbpedia.org/property/>\n" +
"SELECT ?movieLink ?title ?genreLink ?genre ?releaseDate\n" +
"WHERE {\n" +
"    ?movieLink rdf:type db:Film;\n" +
"               foaf:name ?title.\n" +
"    OPTIONAL { ?movieLink prop:genre ?genreLink.\n" +
"               ?genreLink rdfs:label ?genre.\n" +
"               FILTER(lang(?genre) = 'en') }.\n" +
"    OPTIONAL{ ?movieLink <http://dbpedia.org/ontology/releaseDate> ?releaseDate }.\n" +
"\n" +
"    FILTER(lang(?title) = 'en')\n" +
"    FILTER((?releaseDate >= '2010-01-01'^^xsd:date) && (?releaseDate < '2010-12-31'^^xsd:date))\n" +
"}\n" +
"ORDER BY DESC(?releaseDate)\n" +
"LIMIT(10)");
            foreach (SparqlResult result in results)
            {
                Console.WriteLine(result.ToString());
            }

            //Make a DESCRIBE query against the Endpoint
            //IGraph g = endpoint.QueryWithResultGraph("DESCRIBE ");
            //foreach (Triple t in g.Triples)
            //{
            //    Console.WriteLine(t.ToString());
            //}


            //Make a DESCRIBE query against the Endpoint


        }
    }
}
