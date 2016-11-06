using System.Collections.Generic;
using System.Xml;

namespace TestAPP
{
    public class Parser
    {

        public List<Book> ParserMethod()
        {

            List<Book> books = new List<Book>();
            XmlDocument doc = new XmlDocument();
            doc.Load(@"c:\users\matiss\desktop\books.xml");

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/catalog/book");


            foreach (XmlNode node in nodes)
            {
                Book book = new Book();
                book.author = node.SelectSingleNode("author").InnerText;
                book.title = node.SelectSingleNode("title").InnerText;
                book.id = node.Attributes["id"].Value;
                books.Add(book);
            }


            return books;

        }
    }
}
