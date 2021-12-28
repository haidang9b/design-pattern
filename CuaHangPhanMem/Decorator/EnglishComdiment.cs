using DarrenLee.Translator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.Decorator
{
    public class EnglishComdiment : LanguagesComdiment
    {
        public EnglishComdiment(LanguagesDecorator languages)
        {
            base.languages = languages;
        }

        public override string[] Generate(string title, string content)
        {

            title = title + " [" + Translator.Translate(title, "", "en") + "] ";
            content = content + " [" + Translator.Translate(content, "", "en") + "] ";


            return languages.Generate(title, content);
        }
    }
}
