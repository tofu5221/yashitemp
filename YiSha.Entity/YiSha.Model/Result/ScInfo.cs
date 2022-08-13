using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiSha.Util;

namespace YiSha.Model.Result
{
    public class ScInfo
    {
        public int no;
        public int x;
        public int y;
        public int z1;//单深货叉
        public int z2;//双深货叉
        public bool isonload;
        public int taskno;
        public int taskstatus;//1.取货行走；2.取货完成；3.放货行走；4.放货完成
        public int row;
        public int column;
        public int layer;
        //public bool depthL1;//左货叉位置:1.近
        //public bool depthL2;//左货叉位置:2.远
        //public bool depthR1;//右货叉位置:1.近
        //public bool depthR2;//右货叉位置:2.远
        //internal bool _yh;//载货台Y轴高位
        public bool ym;//载货台Y轴中位
        //internal bool _yl;//载货台Y轴低位
        public bool z1leftbusy;//单深货叉正在左出叉
        public bool z1leftarrive;//单深货叉左出叉到位
        public bool z1rightbusy;//单深货叉正在右出叉
        public bool z1rightarrive;//单深货叉右出叉到位
        public bool z2leftbusy;//双深货叉正在左出叉
        public bool z2leftarrive;//双深货叉左出叉到位
        public bool z2rightbusy;//双深货叉正在右出叉
        public bool z2rightarrive;//双深货叉右出叉到位

        public bool yh;//载货台Y轴高位
        public bool yl;//载货台Y轴低位

        public int startx;
        public int starty;
        public int startz1;//单深货叉
        public int destx;
        public int desty;
        public int destz1;//单深货叉
        public int zth = 2;//货叉提升高度
    }
}
