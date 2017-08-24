using System;
using System.Diagnostics;
using System.Collections.Generic;
using Xamarin.Forms;
using CocosSharp;

namespace cocoApp
{
    public partial class MainPage : ContentPage
    {
        CCScene gamescene;
        public MainPage()
        {
            //InitializeComponent();
        
            var layout = new StackLayout();
            this.Content = layout;

            CreateView(layout);
            CreateControls(layout);
        }
        void CreateControls(StackLayout layout)
        {
            // We'll use a StackLayout to organize our buttons
            var stackLayout = new StackLayout() { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.CenterAndExpand };           
            var button = new Button
            {
                Text = "Play?"
            };
            //connect button to action
            button.Clicked += (sender, e) => { Debug.WriteLine("did something"); };
            stackLayout.Children.Add(button);
            layout.Children.Add(stackLayout);
        }
        void CreateView(StackLayout layout)
        {
            // This hosts our game view.
            var gameView = new CocosSharpView()
            {
                // Notice it has the same properties as other XamarinForms Views
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                // This gets called after CocosSharp starts up:
                ViewCreated = HandleViewCreated
            };
            // We'll add it to the top half (row 0)
            layout.Children.Add(gameView);
        }
        void HandleViewCreated(object sender, EventArgs e)
        {
            var gameView = sender as CCGameView;
            if (gameView != null)
            {
                // This sets the game "world" resolution to 100x100:
                gameView.DesignResolution = new CCSizeI(100, 100);
                // GameScene is the root of the CocosSharp rendering hierarchy:
                //gameScene = new GameScene(gameView);
                gamescene = new CCScene(gameView);
                //add sprtie to layer add layer to scene
                var layer = new CCLayerColor();
                var box = new CCDrawNode();
                box.DrawRect(new CCPoint(50, 50), 25, CCColor4B.Red);
                layer.AddChild(box);
                gamescene.AddLayer(layer);
                // Starts CocosSharp:
                gameView.RunWithScene(gamescene);
            }
        }
    }
}
