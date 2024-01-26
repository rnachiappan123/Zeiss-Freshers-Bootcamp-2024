abstract class DocumentPart
{
    String name;
    String position;
    
    public abstract void paint();
    public abstract void save();
    public abstract void convert(ConverterInterface iConverter);
}

class Header extends DocumentPart
{
    String title;
    
    public void paint() {
        System.out.println("paint() called from header");
    }
    
    public void save() {
        System.out.println("save() called from header");
    }
    
    public void convert(ConverterInterface iConverter) {
        iConverter.convert(this);
    }
}

class Paragraph extends DocumentPart
{
    String content;
    String lines;
    
    public void paint() {
        System.out.println("paint() called from paragraph");
    }
    
    public void save() {
        System.out.println("save() called from paragraph");
    }
    
    public void convert(ConverterInterface iConverter) {
        iConverter.convert(this);
    }
}

class HyperLink extends DocumentPart
{
    String url;
    String text;
    
    public void paint() {
        System.out.println("paint() called from hyperlink");
    }
    
    public void save() {
        System.out.println("save() called from hyperlink");
    }
    
    public void convert(ConverterInterface iConverter) {
        iConverter.convert(this);
    }
}

class Footer extends DocumentPart
{
    String text;
    
    public void paint() {
        System.out.println("paint() called from footer");
    }
    
    public void save() {
        System.out.println("save() called from footer");
    }
    
    public void convert(ConverterInterface iConverter) {
        iConverter.convert(this);
    }
}

class WordDocument
{
    DocumentPart[] documentParts;
    
    WordDocument(DocumentPart[] documentPartList) {
        documentParts = documentPartList;
    }
    
    public void open() {
        for (DocumentPart partItem : documentParts) {
            partItem.paint();
            partItem.save();
        }
    }
    
    public void convert(ConverterInterface iConverter) {
        for (DocumentPart partItem : documentParts) {
            partItem.convert(iConverter);
        }
    }
}

interface ConverterInterface
{
    public void convert(Header headerItem);
    public void convert(Paragraph paragraphItem);
    public void convert(HyperLink hyperlinkItem);
    public void convert(Footer footerItem);
}

class HTMLConverter implements ConverterInterface
{
    public void convert(Header headerItem) {
        System.out.println("header converted");
    }
    
    public void convert(Paragraph paragraphItem) {
        System.out.println("paragraph converted");
    }
    
    public void convert(HyperLink hyperlinkItem) {
        System.out.println("hyperlink converted");
    }
    
    public void convert(Footer footerItem) {
        System.out.println("footer converted");
    }
}

class Main
{
    public static void main(String[] args) {
        DocumentPart header1 = new Header();
        DocumentPart paragraph1 = new Paragraph();
        DocumentPart hyperlink1 = new HyperLink();
        DocumentPart footer1 = new Footer();
        
        DocumentPart[] documentPartList = new DocumentPart[]{header1, paragraph1, hyperlink1, footer1};
        WordDocument wordDocument1 = new WordDocument(documentPartList);
        ConverterInterface htmlConverter = new HTMLConverter();
        
        wordDocument1.convert(htmlConverter);
    }
}
