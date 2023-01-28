using CsvHelper;
using CsvHelper.Configuration;
using Cwiczenia3.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Cwiczenia3.Services

{
    public class DbService: IDbService
    {
        private static List<Student> _students = new List<Student>();
        private string _csvDataPath = "Data/studenci.csv";
        private CsvConfiguration configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false,
        };


        public bool AddStudent(Student student)
        {
            ReadStudentsFromCsv();
            if (_students.Any(stud => stud.IndexNumber == student.IndexNumber))
            {
                return false;
            }

            using (var stream = File.Open(_csvDataPath, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, configuration))
            {
                csv.NextRecord();
                csv.WriteRecord<Student>(student);
              
            }
            return true;
        }

        public bool DeleteStudent(string id)
        {
            ReadStudentsFromCsv();
            foreach (var s in _students)
            {
                if (s.IndexNumber == id)
                {
                    _students.Remove(s);
                    WriteStudentsToCsv();
                    return true;
                     
                }
            }
            return false;

            
        }

        public Student GetStudent(string id)
        {
            ReadStudentsFromCsv();
            foreach (var s in _students)
            {
                if (s.IndexNumber == id)
                {
                    return s;

                }
            }
            return null;
        }

        public IEnumerable<Student> GetStudents()
        {
            ReadStudentsFromCsv();
            return _students;
        }

        public bool UpdateStudent(Student student)
        {
            ReadStudentsFromCsv();
            foreach (var s in _students)
            {
                if (s.IndexNumber == student.IndexNumber)
                {
                    _students.Remove(s);
                    _students.Add(student);
                    WriteStudentsToCsv();
                    return true;

                }
            }
            return false;
        }

        private void ReadStudentsFromCsv()
        {
            using (var reader = new StreamReader(_csvDataPath))
            using (var csv = new CsvReader(reader, configuration))
            {
                IEnumerable<Student> records = csv.GetRecords<Student>();
                _students.Clear(); 
                foreach (var s in records)
                {
                    _students.Add(s);
                }
            }
        }
        private void WriteStudentsToCsv()
        {
            using (var writer = new StreamWriter(_csvDataPath))
            using (var csv = new CsvWriter(writer, configuration))
            {
                csv.WriteRecords(_students);
            }
        }




    }
}
