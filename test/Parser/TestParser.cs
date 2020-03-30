using Xunit;
using MarkedNet;

namespace Skclusive.Markdown.Component.Tests
{
    public class TestParser
    {
        [Fact]
        public void TestBlockquote()
        {
                 var text = @"> ⚠️ When `component=""img""`, CardMedia relies on `object-fit` for centering the image. It's not supported by IE 11.

## UI Controls

Supplemental actions within the card are explicitly called out using icons, text, and UI controls, typically placed at the bottom of the card.

Here's an example of a media control card.
";
            var options = new Options();

            var renderer = new MarkdownRenderer();

            options.Renderer = renderer;

            var parser = new MarkdownParser(options);

            var tokensResult = Lexer.Lex(text, options);

            parser.Parse(tokensResult);
        }
    }
}
