using Common.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using TowerDefend.Engine;

namespace TowerDefend.FunctionManagers
{
	public class ImageManager
	{
		private static ImageManager _instance;

		public static ImageManager Instance
		{
			get
			{
				if (_instance == null) _instance = new ImageManager();
				return ImageManager._instance;
			}
		}

		//All towers
		private BitmapImage towerImage = new BitmapImage();
		private List<CroppedBitmap> towerBlocks = new List<CroppedBitmap>();

		//All map blocks
		private BitmapImage mapImage = new BitmapImage();
		private List<CroppedBitmap> mapBlocks = new List<CroppedBitmap>();

		//All Monsters
		private BitmapImage monsterImage = new BitmapImage();
		private List<CroppedBitmap> monsterBlocks = new List<CroppedBitmap>();

		//Bullets
		private BitmapImage starBulletImage = new BitmapImage();
		private BitmapImage sunshineBulletImage = new BitmapImage();

		//Others
		private BitmapImage coinImage = new BitmapImage();
		private BitmapImage redXImage = new BitmapImage();

		//Text
		private BitmapImage textImage = new BitmapImage();
		private List<CroppedBitmap> textBlocks = new List<CroppedBitmap>();

		private ImageManager()
		{
			InitializeImageResources();
		}

		public void InitializeImageResources()
		{
			towerImage.BeginInit();
			towerImage.UriSource = new Uri("pack://application:,,,/Common;component/Resources/tower_suit2.png");
			towerImage.EndInit();

			mapImage.BeginInit();
			mapImage.UriSource = new Uri("pack://application:,,,/Common;component/Resources/map.png");
			mapImage.EndInit();

			monsterImage.BeginInit();
			monsterImage.UriSource = new Uri("pack://application:,,,/Common;component/Resources/monster_suit1.png");
			monsterImage.EndInit();

			mapBlocks = InitializeImageBlocks(mapImage, 61, 28, 16, 16, 1, 1);
			monsterBlocks = InitializeImageBlocks(monsterImage, 12, 8, 32, 32, 0, 0);
			towerBlocks = InitializeImageBlocks(towerImage, 5, 3, 68, 68, 0, 0);


			starBulletImage.BeginInit();
			starBulletImage.UriSource = new Uri("pack://application:,,,/Common;component/Resources/starbullet.gif");
			starBulletImage.EndInit();

			sunshineBulletImage.BeginInit();
			sunshineBulletImage.UriSource = new Uri("pack://application:,,,/Common;component/Resources/sunshine.png");
			sunshineBulletImage.EndInit();

			coinImage.BeginInit();
			coinImage.UriSource = new Uri("pack://application:,,,/Common;component/Resources/coin.png");
			coinImage.EndInit();

			redXImage.BeginInit();
			redXImage.UriSource = new Uri("pack://application:,,,/Common;component/Resources/redx.png");
			redXImage.EndInit();

			textImage.BeginInit();
			textImage.UriSource = new Uri("pack://application:,,,/Common;component/Resources/font_suit1.png");
			textImage.EndInit();
			textBlocks = InitializeImageBlocks(textImage, 8, 12, 34, 43, 0, 0);
		}

		/// <summary>
		/// Split image into blocks
		/// </summary>
		/// <param name="img"></param>
		/// <param name="widthBlockCount"></param>
		/// <param name="heightBlockCount"></param>
		/// <returns></returns>
		private List<CroppedBitmap> InitializeImageBlocks(BitmapImage img, int widthBlockCount, int heightBlockCount, int width, int height, int rowAlter, int colAlter)
		{
			List<CroppedBitmap> result = new List<CroppedBitmap>();
			for (int j = 0; j < heightBlockCount; j++)
			{
				for (int i = 0; i < widthBlockCount; i++)
				{
					result.Add(new CroppedBitmap(img, new Int32Rect(i * (width + rowAlter) + rowAlter, j * (height + colAlter) + colAlter, width, height)));
				}
			}
			return result;
		}

		public CroppedBitmap GetMapNode(MapNodeType m)
		{
			return mapBlocks[(int)m];
		}

		public CroppedBitmap GetMonsterNode(MonsterNodeType m)
		{
			return monsterBlocks[(int)m];
		}

		public CroppedBitmap GetTowerImage(TowerNodeType m)
		{
			return towerBlocks[(int)m];
		}

		public BitmapImage GetImageByName(ImageNames name)
		{
			switch (name)
			{
 				case ImageNames.Coin:
					return coinImage;
				case ImageNames.RedX:
					return redXImage;
				case ImageNames.StarBullet:
					return starBulletImage;
				case ImageNames.SunshineBullet:
					return sunshineBulletImage;
				default:
					return null;
			}
		}

		public CroppedBitmap GetTextImage(char c)
		{
			//A ascii = 65
			char[] cc = new char[1];
			cc[0] = c;
			byte[] asc = ASCIIEncoding.ASCII.GetBytes(cc);

			if(asc[0] >= 65 && asc[0] <= 91)
				return textBlocks[asc[0] - 65];

			switch (c)
			{
				case ':':
					{
						return textBlocks[65];
					}
 				case '0':
					{
						return textBlocks[52];
					}
				case '1':
					{
						return textBlocks[53];
					}
				case '2':
					{
						return textBlocks[54];
					}
				case '3':
					{
						return textBlocks[55];
					}
				case '4':
					{
						return textBlocks[56];
					}
				case '5':
					{
						return textBlocks[57];
					}
				case '6':
					{
						return textBlocks[58];
					}
				case '7':
					{
						return textBlocks[59];
					}
				case '8':
					{
						return textBlocks[60];
					}
				case '9':
					{
						return textBlocks[61];
					}
				default:
					return textBlocks[95];
			}
		}
	}

}
