﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Svg.Skia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXBasicStudio.DocumentEditors.ZXGraphics.log;
using ZXBasicStudio.DocumentModel.Enums;
using ZXBasicStudio.DocumentModel.Interfaces;

namespace ZXBasicStudio.IntegratedDocumentTypes.CodeDocuments.ZXGraphics
{
    public class FontDocument : IZXDocumentType
    {
        static readonly string[] _docExtensions = { ".fnt" };
        static readonly string _docName = "ZX Font file";
        static readonly string _docDesc = "User font (96 chars). Array of 768 bytes to use as custom font in ZX Spectrum 48K/128K models";
        static readonly string _docCat = "Graphics";
        static readonly string _docAspect = "/Svg/Documents/file-font.svg";

        static readonly FontDocumentFactory _factory = new FontDocumentFactory();
        Bitmap? _icon;

        public string[] DocumentExtensions => _docExtensions;
        public string DocumentName => _docName;
        public string DocumentDescription => _docDesc;
        public string DocumentCategory => _docCat;
        public string? DocumentAspect => _docAspect;

        private static readonly ExportManager _exportManager = new ExportManager();


        public FontDocument()
        {
            _exportManager.Initialize(DocumentEditors.ZXGraphics.neg.FileTypes.Font);
        }


        public Bitmap DocumentIcon
        {
            get
            {
                if (_icon == null)
                {
                    var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();

                    if (assets == null)
                        throw new AvaloniaInternalException("Cannot create assets loader");

                    _icon = new Bitmap(assets.Open(new Uri("avares://ZXBasicStudio/Assets/zxGraphics_fnt.png")));
                }

                return _icon;
            }
        }

        public bool CanCreate => true;

        public bool CanEdit => true;

        public IZXDocumentFactory DocumentFactory => _factory;

        public IZXDocumentBuilder? DocumentBuilder => _exportManager;

        public ZXBuildStage? DocumentBuildStage => ZXBuildStage.PreBuild;
    }
}