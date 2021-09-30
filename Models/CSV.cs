using AvailityHomework.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Availity_Test.Models
{
    public class CSV : ICsv
    {
        public void ReadAndWriteCSVs(string csvInFilePath)
        {
            // For reading an actual .csv from a file location, this is how I'd set it up. Could be different if you wanted to run tests easily on it, then
            // this might be a StreamReader setup, etc., just to see it sorting, etc., outside of an actual application
            using (TextFieldParser parser = new TextFieldParser(csvInFilePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                var enrolleeList = new List<Enrollee>();

                while (!parser.EndOfData)
                {
                    // separates data into rows
                    string[] fields = parser.ReadFields();

                    // add each row to the list of strongly-typed objects

                    // of course, all of this depends on valid data coming in, nulls, etc, and whether the value for Version can be parsed
                    // could do a TryParse instead, and install guardrails for null checking, etc., if necessary (see Version below)

                    // probably would wrap this in a top-level Try/Catch as well

                    enrolleeList.Add(new Enrollee
                    {
                        UserID = fields[0],
                        LastName = fields[1],
                        FirstName = fields[2],
                        Version = int.TryParse(fields[3], out int intValue) ? intValue : 0,
                        InsuranceCo = fields[4]
                    });
                    ;
                }

                // group by UserID, taking top Version 
                var byInsCo = enrolleeList.GroupBy(g => g.InsuranceCo);

                foreach (var group in byInsCo)
                {
                    // then remove duplicates by version
                    var byTopVersion = group.GroupBy(g => g.UserID).Select(s => s.OrderByDescending(o => o.Version).First());

                    // filter by name
                    var filteredByName = byTopVersion.OrderBy(o => o.LastName).ThenBy(o => o.FirstName).ToList();

                    // then write to file... here there's lots of options depending on the type of file one wants to create, so this is kind of 
                    // where I'm taking a bit of a shortcut and throwing this just into a memory stream. You can get into serialization, third-party
                    // software to write it back as a .csv, etc. Would have to establish the file path to write to disk and then save the serialization into
                    // the path with a Write-To method.
                    StreamWriter streamWriter = new StreamWriter(filteredByName.ToString());
                }
            }
        }
    }

    public class Enrollee
    {
        public string UserID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Version { get; set; }
        public string InsuranceCo { get; set; }
    }
}