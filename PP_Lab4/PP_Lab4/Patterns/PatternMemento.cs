using System;
using System.Collections.Generic;

namespace PP_Lab4.Patterns
{
    public class Memento
    {
        private List<string> _Shapes;

        public Memento(List<string> shapes)
        {
            _Shapes = new List<string>(shapes);
        }

        public List<string> getShapes()
        {
            return _Shapes;
        }
    }

    public class Picture
    {
        private List<string> _Shapes;

        public Picture()
        {
            _Shapes = new List<string>();
        }

        public Memento Save()
        {
            return new Memento(_Shapes);
        }

        public void ReDraw(Memento memento)
        {
            _Shapes = memento.getShapes();
        }

        public void ShowPicture()
        {
            Console.Write("On this picture: ");
            foreach (string shape in _Shapes)
                Console.Write(shape + " ");
            Console.WriteLine();
        }
        public void AddShape(string shape)
        {
            _Shapes.Add(shape);
        }
    }

    public class GraphicEditor
    {
        private Picture _Picture { get; set; }
        private Stack<Memento> _History { get; set; }
        
        public GraphicEditor()
        {
            _Picture = new Picture();
            _History = new Stack<Memento>();
        }

        public void ShowPicture()
        {
            _Picture.ShowPicture();
        }

        public void AddShape(string shape)
        {
            _Picture.AddShape(shape);
        }

        public void Save()
        {
            _History.Push(_Picture.Save());
        }

        public void Undo()
        {
            if (_History.Count > 0)
                _Picture.ReDraw(_History.Pop());
        }
    }
}
