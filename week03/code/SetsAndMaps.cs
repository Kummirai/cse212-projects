using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        //1. Create a HashSet to store the words we have seen so far
        //2. Create a list to store the pairs we find.
        //3. Iterate through each word in the input array and Reverse the current word and Check if the reversed word exists in the HashSet
        // 4. If it does, add the pair to the pairs list in a consistent order (e.g., "am & ma") andIf it does not, add the current word to the HashSet

        HashSet<string> seenWords = new HashSet<string>();
        List<string> pairs = new List<string>();

        foreach (var word in words)
        {
            var reversedWord = new string(word.Reverse().ToArray());
            if (seenWords.Contains(reversedWord))
            {
                pairs.Add($"{reversedWord} & {word}");
            }
            else
            {
                seenWords.Add(word);
            }
        }

        return pairs.ToArray();
    }
    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {

        // TODO Problem 2 - ADD YOUR CODE HERE
        //1. Create a dictionary to store the degree counts.
        //2. Read the file line by line and split each line into fields using the comma as a delimiter.
        //3. For each line, check if there are at least 4 fields to ensure the degree information is present. If so, extract the degree from the 4th field.
        //4. Update the count for that degree in the dictionary. If the degree is already a key in the dictionary, increment its count. If not, add it to the dictionary with a count of 1.

        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            if (fields.Length > 3)
            {
                string degree = fields[3];
                if (degrees.ContainsKey(degree))
                {
                    degrees[degree]++;
                }
                else
                {
                    degrees[degree] = 1;
                }
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE

        //1. Normalize the input words by removing spaces and converting them to lower case.
        //2. Check if the lengths of the normalized words are different. If they are,
        //   return false immediately since they cannot be anagrams.
        //3. Create a dictionary to count the occurrences of each character in the first word.
        //4. Iterate through the characters of the first word and update the counts in the dictionary.
        //5. Iterate through the characters of the second word and decrement the counts in the dictionary. If a character is not found or if any count becomes negative, return false.
        //6. If all counts are zero at the end, return true.

        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
        {
            return false;
        }

        Dictionary<char, int> count = new Dictionary<char, int>();

        foreach (char c in word1)
        {
            if (count.ContainsKey(c))
            {
                count[c]++;
            }
            else
            {
                count[c] = 1;
            }
        }

        foreach (char c in word2)
        {
            if (!count.ContainsKey(c))
            {
                return false;
            }

            count[c]--;

            if (count[c] < 0)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return [];
    }
}