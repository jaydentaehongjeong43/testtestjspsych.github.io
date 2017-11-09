using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaKaoTalkParser
{
    class KaKaoParsing
    {
        string[] lines;
        public KaKaoParsing(string original)
        {
            lines = original.Split('\r');
        }

        public string[] parseText(int n)
        {
            List<String> result = new List<String>();
            for(int i=2; i < lines.Length; i++)
            {
                lines[i] = lines[i].Replace("\n", "");
                string[] check = lines[i].Split(' ');
                
                switch (n)
                {
                    case 1:

                        if (check.Length > 7 && check[5].Equals("회원님"))   // 걸러내야 할 내용
                        {
                            string temp = lines[i].Substring(lines[i].IndexOf(','));
                            temp = temp.Substring(temp.IndexOf(':') + 1);
                            result.Add(temp);
                        }
                        else if (check.Length < 5)                            // 대화 내용 중 엔터가 있는 경우
                        {
                            if (result.Count == 0) continue;
                            string temp = result.Last();
                            result.RemoveAt(result.Count - 1);
                            temp += ' ' + lines[i];
                            result.Add(temp);

                        }
                        else if (lines[i].IndexOf('년') != 4)                 // 대화 내용 중 엔터가 있는 경우. 다른 사람이라면 '년'이 있음.
                        {
                            if (result.Count == 0) continue;
                            string temp = result.Last();
                            result.RemoveAt(result.Count - 1);
                            temp += ' ' + lines[i];
                            result.Add(temp);
                        }
                        break;
                    case 2:
                        if (check.Length > 7 && check[5]!="회원님")   // 걸러내야 할 내용
                        {
                            string temp = lines[i].Substring(lines[i].IndexOf(','));
                            temp = temp.Substring(temp.IndexOf(':') + 1);
                            result.Add(temp);
                        }
                        else if (check.Length < 5)                            // 대화 내용 중 엔터가 있는 경우
                        {
                            if (result.Count == 0) continue;
                            string temp = result.Last();
                            result.RemoveAt(result.Count - 1);
                            temp += ' ' + lines[i];
                            result.Add(temp);

                        }
                        else if (lines[i].IndexOf('년') != 4)                 // 대화 내용 중 엔터가 있는 경우. 다른 사람이라면 '년'이 있음.
                        {
                            if (result.Count == 0) continue;
                            string temp = result.Last();
                            result.RemoveAt(result.Count - 1);
                            temp += ' ' + lines[i];
                            result.Add(temp);
                        }
                        break;
                    case 3:
                        if (check.Length > 7 )   // 걸러내야 할 내용
                        {
                            string temp = lines[i].Substring(lines[i].IndexOf(','));
                            temp = temp.Substring(temp.IndexOf(':') + 1);
                            result.Add(temp);
                        }
                        else if (check.Length < 5)                            // 대화 내용 중 엔터가 있는 경우
                        {
                            if (result.Count == 0) continue;
                            string temp = result.Last();
                            result.RemoveAt(result.Count - 1);
                            temp += ' ' + lines[i];
                            result.Add(temp);

                        }
                        else if (lines[i].IndexOf('년') != 4)                 // 대화 내용 중 엔터가 있는 경우. 다른 사람이라면 '년'이 있음.
                        {
                            if (result.Count == 0) continue;
                            string temp = result.Last();
                            result.RemoveAt(result.Count - 1);
                            temp += ' ' + lines[i];
                            result.Add(temp);
                        }
                        break;

                }
                
            }
            return result.ToArray();
        }


        public int countWord(string[] result)
        {
            int count=0;
            for(int i=0; i<result.Length; i++)
            {
                string[] temp = result[i].Split(' ');
                count += temp.Length;
            }
            return count;
        }

    }
}
