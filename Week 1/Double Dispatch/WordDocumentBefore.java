abstract class DocumentPart
{
    String name;
    String position;
    
    public abstract void paint();
    public abstract void save();
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
        wordDocument1.open();
    }
}