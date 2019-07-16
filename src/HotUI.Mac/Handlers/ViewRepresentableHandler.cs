﻿using AppKit;

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable MemberCanBePrivate.Global

namespace HotUI.Mac.Handlers
{
    public class ViewRepresentableHandler : AbstractHandler<ViewRepresentable, NSView>
    {
        public static readonly PropertyMapper<ViewRepresentable> Mapper = new PropertyMapper<ViewRepresentable>(ViewHandler.Mapper)
        {
            [nameof(ViewRepresentable.Data)] = MapDataProperty
        };
        
        public ViewRepresentableHandler() : base(Mapper)
        {

        }

        protected override NSView CreateView()
        {
            return VirtualView?.MakeView() as NSView;
        }

        protected override void DisposeView(NSView nativeView)
        {
            
        }

        public static void MapDataProperty(IViewHandler viewHandler, ViewRepresentable virtualView)
        { 
            var data = virtualView.Data;
            virtualView.UpdateView?.Invoke(viewHandler.NativeView, data);
        }
    }
}