using System;
using System.IO;
using System.Collections;

public class DataReader : IEnumerable
{
    private double[]? data;
//reads double from binary file
        public DataReader(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"The file '{filename}' couldn’t be found.");
            return;
        }

        using (BinaryReader reader = new BinaryReader(File.OpenRead(filename)))
        {
            long fileLength = new FileInfo(filename).Length;
            if (fileLength == 0)
            {
                Console.WriteLine("The file is empty.");
                return;
            }

            int numDoubles = (int)(fileLength / sizeof(double));
            data = new double[numDoubles];

            for (int i = 0; i < numDoubles; i++)
            {
                data[i] = reader.ReadDouble();
            }
        }
    }

//returns num of double
    public int Count
    {
        get
        {
            if (data == null)
            {
                Console.WriteLine("No data loaded, so the count is 0.");
                return 0;
            }
            return data.Length;
        }
    }

    public double this[int index]
    {
        get
        {
            if (data == null)
            {
                Console.WriteLine("No data to grab—nothing was loaded!");
                return 0;
            }
            if (index < 0 || index >= data.Length)
            {
                Console.WriteLine($"Index {index} is out of bounds!");
                return 0;
            }
            return data[index];
        }
    }

    public IEnumerator GetEnumerator()
    {
        if (data == null)
        {
            Console.WriteLine("Nothing to enumerate—no data loaded!");
            return new DataReaderEnum(new double[0]);
        }
        return new DataReaderEnum(data);
    }
}
