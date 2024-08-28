using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using DocToolkit;

namespace Inventec.DrawTools
{
  /// <summary>
  /// Working area.
  /// Handles mouse input and draws graphics objects.
  /// </summary>
  internal partial class DrawArea : UserControl
  {
    #region Constructor, Dispose
    public DrawArea()
    {
      // create list of Layers, with one default active visible layer
      _layers = new Layers();
      _layers.CreateNewLayer("Default");
      _panning = false;
      _panX = 0;
      _panY = 0;
      this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.DrawArea_MouseWheel);
      // This call is required by the Windows.Forms Form Designer.
      InitializeComponent();
      //DrawImage o = new DrawImage(0, 0);
      //DrawTools.ToolObject.AddNewObject(this, new DrawImage(0, 0));

    }
    #endregion Constructor, Dispose

    #region Enumerations
    public enum DrawToolType
    {
      Pointer,
      Rectangle,
      Ellipse,
      Line,
      PolyLine,
      Polygon,
      Text,
      Image,
      Connector,
      NumberOfDrawTools
    } ;
    #endregion Enumerations

    #region Members
    private float _zoom = 1.0f;
    private float _rotation = 0f;
    private int _panX = 0;
    private int _panY;
    private int _originalPanY;
    private bool _panning = false;
    private Point lastPoint;
    private Color _lineColor = Color.Black;
    private Color _fillColor = Color.White;
    private bool _drawFilled = false;
    private int _lineWidth = -1;
    private Pen _currentPen;
    private DrawingPens.PenType _penType;
    private Brush _currentBrush;
    private FillBrushes.BrushType _brushType;

    // Define the Layers collection
    private Layers _layers;

    private DrawToolType activeTool; // active drawing tool
    private Tool[] tools; // array of tools

    // Information about owner form
    private frmDrawTools owner;
    private DocManager docManager;

    // group selection rectangle
    private Rectangle netRectangle;
    private bool drawNetRectangle = false;

    private Form myparent;

    public Form MyParent
    {
      get { return myparent; }
      set { myparent = value; }
    }

    private UndoManager undoManager;
    #endregion Members

    #region Properties
    /// <summary>
    /// Allow tools and objects to see the type of brush set
    /// </summary>
    public FillBrushes.BrushType BrushType
    {
      get { return _brushType; }
      set { _brushType = value; }
    }

    public Brush CurrentBrush
    {
      get { return _currentBrush; }
      set { _currentBrush = value; }
    }

    /// <summary>
    /// Allow tools and objects to see the type of pen set
    /// </summary>
    public DrawingPens.PenType PenType
    {
      get { return _penType; }
      set { _penType = value; }
    }

    /// <summary>
    /// Current Drawing Pen
    /// </summary>
    public Pen CurrentPen
    {
      get { return _currentPen; }
      set { _currentPen = value; }
    }

    /// <summary>
    /// Current Line Width
    /// </summary>
    public int LineWidth
    {
      get { return _lineWidth; }
      set { _lineWidth = value; }
    }

    /// <summary>
    /// Flag determines if objects will be drawn filled or not
    /// </summary>
    public bool DrawFilled
    {
      get { return _drawFilled; }
      set { _drawFilled = value; }
    }

    /// <summary>
    /// Color to draw filled objects with
    /// </summary>
    public Color FillColor
    {
      get { return _fillColor; }
      set { _fillColor = value; }
    }

    /// <summary>
    /// Color for drawing lines
    /// </summary>
    public Color LineColor
    {
      get { return _lineColor; }
      set { _lineColor = value; }
    }

    /// <summary>
    /// Original Y position - used when panning
    /// </summary>
    public int OriginalPanY
    {
      get { return _originalPanY; }
      set { _originalPanY = value; }
    }

    /// <summary>
    /// Flag is true if panning active
    /// </summary>
    public bool Panning
    {
      get { return _panning; }
      set { _panning = value; }
    }

    /// <summary>
    /// Current pan offset along X-axis
    /// </summary>
    public int PanX
    {
      get { return _panX; }
      set { _panX = value; }
    }

    /// <summary>
    /// Current pan offset along Y-axis
    /// </summary>
    public int PanY
    {
      get { return _panY; }
      set { _panY = value; }
    }

    /// <summary>
    /// Degrees of rotation of the drawing
    /// </summary>
    public float Rotation
    {
      get { return _rotation; }
      set { _rotation = value; }
    }

    /// <summary>
    /// Current Zoom factor
    /// </summary>
    public float Zoom
    {
      get { return _zoom; }
      set { _zoom = value; }
    }

    /// <summary>
    /// Group selection rectangle. Used for drawing.
    /// </summary>
    public Rectangle NetRectangle
    {
      get { return netRectangle; }
      set { netRectangle = value; }
    }

    /// <summary>
    /// Flag is set to true if group selection rectangle should be drawn.
    /// </summary>
    public bool DrawNetRectangle
    {
      get { return drawNetRectangle; }
      set { drawNetRectangle = value; }
    }

    /// <summary>
    /// Reference to the owner form
    /// </summary>
    public frmDrawTools Owner
    {
      get { return owner; }
      set { owner = value; }
    }

    /// <summary>
    /// Reference to DocManager
    /// </summary>
    public DocManager DocManager
    {
      get { return docManager; }
      set { docManager = value; }
    }

    /// <summary>
    /// Active drawing tool.
    /// </summary>
    public DrawToolType ActiveTool
    {
      get { return activeTool; }
      set { activeTool = value; }
    }

    /// <summary>
    /// List of Layers in the drawing
    /// </summary>
    public Layers TheLayers
    {
      get { return _layers; }
      set { _layers = value; }
    }

    /// <summary>
    /// Return True if Undo operation is possible
    /// </summary>
    public bool CanUndo
    {
      get
      {
        if (undoManager != null)
        {
          return undoManager.CanUndo;
        }

        return false;
      }
    }

    /// <summary>
    /// Return True if Redo operation is possible
    /// </summary>
    public bool CanRedo
    {
      get
      {
        if (undoManager != null)
        {
          return undoManager.CanRedo;
        }

        return false;
      }
    }

    #endregion

    #region Event Handlers
    /// <summary>
    /// Draw graphic objects and group selection rectangle (optionally)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DrawArea_Paint(object sender, PaintEventArgs e)
    {
      Matrix mx = new Matrix();
      mx.Translate(-ClientSize.Width / 2f, -ClientSize.Height / 2f, MatrixOrder.Append);
      mx.Rotate(_rotation, MatrixOrder.Append);
      mx.Translate(ClientSize.Width / 2f + _panX, ClientSize.Height / 2f + _panY, MatrixOrder.Append);
      mx.Scale(_zoom, _zoom, MatrixOrder.Append);
      e.Graphics.Transform = mx;
      // Determine center of ClientRectangle
      Point centerRectangle = new Point();
      centerRectangle.X = ClientRectangle.Left + ClientRectangle.Width / 2;
      centerRectangle.Y = ClientRectangle.Top + ClientRectangle.Height / 2;
      // Get true center point
      centerRectangle = BackTrackMouse(centerRectangle);
      // Determine offset from current mouse position

      SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
      e.Graphics.FillRectangle(brush,
                   ClientRectangle);
      // Draw objects on each layer, in succession so we get the correct layering. Only draw layers that are visible
      if (_layers != null)
      {
        int lc = _layers.Count;
        for (int i = 0; i < lc; i++)
        {
          Console.WriteLine(String.Format("Layer {0} is Visible: {1}", i.ToString(), _layers[i].IsVisible.ToString()));
          if (_layers[i].IsVisible)
          {
            if (_layers[i].Graphics != null)
              _layers[i].Graphics.Draw(e.Graphics);
          }
        }
      }

      DrawNetSelection(e.Graphics);

      brush.Dispose();
    }

    /// <summary>
    /// Back Track the Mouse to return accurate coordinates regardless of zoom or pan effects.
    /// Courtesy of BobPowell.net <seealso cref="http://www.bobpowell.net/backtrack.htm"/>
    /// </summary>
    /// <param name="p">Point to backtrack</param>
    /// <returns>Backtracked point</returns>
    public Point BackTrackMouse(Point p)
    {
      // Backtrack the mouse...
      Point[] pts = new Point[] { p };
      Matrix mx = new Matrix();
      mx.Translate(-ClientSize.Width / 2f, -ClientSize.Height / 2f, MatrixOrder.Append);
      mx.Rotate(_rotation, MatrixOrder.Append);
      mx.Translate(ClientSize.Width / 2f + _panX, ClientSize.Height / 2f + _panY, MatrixOrder.Append);
      mx.Scale(_zoom, _zoom, MatrixOrder.Append);
      mx.Invert();
      mx.TransformPoints(pts);
      return pts[0];
    }

    /// <summary>
    /// Mouse down.
    /// Left button down event is passed to active tool.
    /// Right button down event is handled in this class.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void DrawArea_MouseDown(object sender, MouseEventArgs e)
    {
      lastPoint = BackTrackMouse(e.Location);
      if (e.Button == MouseButtons.Left)
        tools[(int)activeTool].OnMouseDown(this, e);
      else if (e.Button == MouseButtons.Right)
      {
        if (_panning)
          _panning = false;
        if (activeTool == DrawToolType.PolyLine || activeTool == DrawToolType.Connector)
          tools[(int)activeTool].OnMouseDown(this, e);
        ActiveTool = DrawToolType.Pointer;
        OnContextMenu(e);
      }
    }

    //        else if (e.Button == MouseButtons.Right)
    //{
    //if (_panning == true)
    //_panning = false; 

    //if (activeTool == DrawToolType.PolyLine)
    //tools[(int)activeTool].OnMouseDown(this, e);

    //ActiveTool = TETemplateDrawArea.DrawToolType.Pointer;
    //}

    /// <summary>
    /// Mouse move.
    /// Moving without button pressed or with left button pressed
    /// is passed to active tool.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void DrawArea_MouseMove(object sender, MouseEventArgs e)
    {
      Point curLoc = BackTrackMouse(e.Location);
      if (e.Button == MouseButtons.Left ||
        e.Button == MouseButtons.None)
        if (e.Button == MouseButtons.Left && _panning)
        {
          if (curLoc.X !=
            lastPoint.X)
            _panX += curLoc.X - lastPoint.X;
          if (curLoc.Y !=
            lastPoint.Y)
            _panY += curLoc.Y - lastPoint.Y;
          Invalidate();
        }
        else
          tools[(int)activeTool].OnMouseMove(this, e);
      else
        Cursor = Cursors.Default;
      lastPoint = BackTrackMouse(e.Location);
    }

    /// <summary>
    /// Mouse up event.
    /// Left button up event is passed to active tool.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void DrawArea_MouseUp(object sender, MouseEventArgs e)
    {
      //lastPoint = BackTrackMouse(e.Location);
      if (e.Button ==
        MouseButtons.Left)
      {
        //this.AddCommandToHistory(new CommandAdd(this.TheLayers[al].Graphics[0]));
        tools[(int)activeTool].OnMouseUp(this, e);
      }
    }
    #endregion

    #region Other Functions
    /// <summary>
    /// Initialization
    /// </summary>
    /// <param name="owner">Reference to the owner form</param>
    /// <param name="docManager">Reference to Document manager</param>
    public void Initialize(frmDrawTools owner, DocManager docManager)
    {
      SetStyle(ControlStyles.AllPaintingInWmPaint |
           ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
      Invalidate();

      // Keep reference to owner form
      Owner = owner;
      DocManager = docManager;

      // set default tool
      activeTool = DrawToolType.Pointer;

      // Create undo manager
      undoManager = new UndoManager(_layers);

      // create array of drawing tools
      tools = new Tool[(int)DrawToolType.NumberOfDrawTools];
      tools[(int)DrawToolType.Pointer] = new ToolPointer();
      tools[(int)DrawToolType.Rectangle] = new ToolRectangle();
      tools[(int)DrawToolType.Ellipse] = new ToolEllipse();
      tools[(int)DrawToolType.Line] = new ToolLine();
      tools[(int)DrawToolType.PolyLine] = new ToolPolyLine();
      tools[(int)DrawToolType.Polygon] = new ToolPolygon();
      tools[(int)DrawToolType.Text] = new ToolText();
      tools[(int)DrawToolType.Image] = new ToolImage();
      tools[(int)DrawToolType.Connector] = new ToolConnector();

      LineColor = Color.Black;
      FillColor = Color.White;
      LineWidth = -1;
    }

    /// <summary>
    /// Add command to history.
    /// </summary>
    public void AddCommandToHistory(Command command)
    {
      undoManager.AddCommandToHistory(command);
    }

    /// <summary>
    /// Clear Undo history.
    /// </summary>
    public void ClearHistory()
    {
      undoManager.ClearHistory();
    }

    /// <summary>
    /// Undo
    /// </summary>
    public void Undo()
    {
      undoManager.Undo();
      Refresh();
    }

    /// <summary>
    /// Redo
    /// </summary>
    public void Redo()
    {
      undoManager.Redo();
      Refresh();
    }

    /// <summary>
    ///  Draw group selection rectangle
    /// </summary>
    /// <param name="g"></param>
    public void DrawNetSelection(Graphics g)
    {
      if (!DrawNetRectangle)
        return;

      ControlPaint.DrawFocusRectangle(g, NetRectangle, Color.Black, Color.Transparent);
    }

    /// <summary>
    /// Right-click handler
    /// </summary>
    /// <param name="e"></param>
    private void OnContextMenu(MouseEventArgs e)
    {
      // Change current selection if necessary

      Point point = BackTrackMouse(new Point(e.X, e.Y));
      Point menuPoint = new Point(e.X, e.Y);
      int al = _layers.ActiveLayerIndex;
      int n = _layers[al].Graphics.Count;
      DrawObject o = null;

      for (int i = 0; i < n; i++)
      {
        if (_layers[al].Graphics[i].HitTest(point) == 0)
        {
          o = _layers[al].Graphics[i];
          break;
        }
      }

      if (o != null)
      {
        if (!o.Selected)
          _layers[al].Graphics.UnselectAll();

        // Select clicked object
        o.Selected = true;
      }
      else
      {
        _layers[al].Graphics.UnselectAll();
      }

      Refresh();
      Owner.ctxtMenu.Show(this, menuPoint);
    }
    #endregion

    public void CutObject()
    {
      MessageBox.Show("Cut (from drawarea)");
    }
    private void DrawArea_MouseWheel(object sender, MouseEventArgs e)
    {
    }

  }
}