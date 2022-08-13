using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
//using YiSha.Entity.BinfoManage;
//using YiSha.Model.Param.BinfoManage;
//using YiSha.Service.BinfoManage;
using YiSha.Model.Result;
using System.Threading;

namespace YiSha.Business.BinfoManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2022-03-30 21:05
    /// 描 述：业务类
    /// </summary>
    public class ScBLL
    {
        public static List<ScInfo> scInfos = new List<ScInfo>();
        private static Thread threadSCx = new Thread(new ThreadStart(SyncSCx));
        private static bool threadSCxGoon = true;
        private static Thread threadSCy = new Thread(new ThreadStart(SyncSCy));
        private static bool threadSCyGoon = true;
        private static Thread threadSCz = new Thread(new ThreadStart(SyncSCz));
        private static bool threadSCzGoon = true;

        static ScBLL()
        {
            if (scInfos.Count == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    ScInfo scInfo = new ScInfo();
                    scInfo.no = i + 1;
                    scInfos.Add(scInfo);
                }
                scInfos[0].x = 0;
                scInfos[1].x = 1000;
                scInfos[2].x = 0;
                scInfos[3].x = 1000;

                scInfos[0].startx = 0;
                scInfos[1].startx = 1000;
                scInfos[2].startx = 0;
                scInfos[3].startx = 1000;

                scInfos[0].starty = 0;
                scInfos[1].starty = 0;
                scInfos[2].starty = 0;
                scInfos[3].starty = 0;

                scInfos[0].startz1 = 18;
                scInfos[1].startz1 = 18;
                scInfos[2].startz1 = 18;
                scInfos[3].startz1 = 18;

                scInfos[0].destx = 350;
                scInfos[1].destx = 450;
                scInfos[2].destx = 450;
                scInfos[3].destx = 550;

                scInfos[0].desty = 40;
                scInfos[1].desty = 60;
                scInfos[2].desty = 60;
                scInfos[3].desty = 80;

                scInfos[0].destz1 = 18;
                scInfos[1].destz1 = 18;
                scInfos[2].destz1 = 18;
                scInfos[3].destz1 = 18;

                if (threadSCx.ThreadState == ThreadState.Unstarted)
                    threadSCx.Start();
                if (threadSCy.ThreadState == ThreadState.Unstarted)
                    threadSCy.Start();
                if (threadSCz.ThreadState == ThreadState.Unstarted)
                    threadSCz.Start();
            }
        }

        public ScBLL()
        {

        }

        #region 获取数据
        public async Task<TData<List<ScInfo>>> GetList(string no)
        {

            TData<List<ScInfo>> obj = new TData<List<ScInfo>>();
            string[] noList = no.Split(',');
            int[] noListint = new int[noList.Length];
            for (int i = 0; i < noList.Length; i++)
            {
                noListint[i]= int.Parse(noList[i]);
            }
            obj.Data =  scInfos.Where(p => noListint.Contains(p.no)).ToList();

            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 提交数据
        #endregion

        #region 私有方法
        private static void SyncSCx()
        {
            while (threadSCxGoon)
            {
                foreach (ScInfo scInfo in scInfos)
                {
                    if (new int[] { 1, 2, 3, 4 }.Contains(scInfo.no))
                    {
                        if (new int[] { 0, 1 }.Contains(scInfo.taskstatus))//取货行走
                        {
                            if (scInfo.x < scInfo.startx)
                            {
                                scInfo.x++;
                                scInfo.taskstatus = 1;
                            }
                            else if (scInfo.x > scInfo.startx)
                            {
                                scInfo.x--;
                                scInfo.taskstatus = 1;
                            }
                        }
                        else if (scInfo.taskstatus == 5)//放货行走
                        {
                            if (scInfo.x < scInfo.destx)
                            {
                                scInfo.x++;
                            }
                            else if (scInfo.x > scInfo.destx)
                            {
                                scInfo.x--;
                            }
                        }
                    }
                    //obj.Message += string.Format("{0}号堆垛机仿真：x:{1};y:{2};z:{3};s:{4}。", scInfo.no, scInfo.x, scInfo.y, scInfo.z1, scInfo.taskstatus);
                }
                Thread.Sleep(200);
            }
        }

        private static void SyncSCy()
        {
            while (threadSCyGoon)
            {
                foreach (ScInfo scInfo in scInfos)
                {
                    if (new int[] { 1, 2, 3, 4 }.Contains(scInfo.no))
                    {
                        if (new int[] { 0, 1 }.Contains(scInfo.taskstatus))//取货行走
                        {
                            if (scInfo.y < scInfo.starty)
                            {
                                scInfo.y++;
                                scInfo.taskstatus = 1;
                            }
                            else if (scInfo.y > scInfo.starty)
                            {
                                scInfo.y--;
                                scInfo.taskstatus = 1;
                            }
                            if (scInfo.x == scInfo.startx && scInfo.y == scInfo.starty)
                            {
                                scInfo.taskstatus = 2;
                            }
                        }
                        else if (scInfo.taskstatus == 3)//取货伸叉后提起
                        {
                            if (scInfo.x == scInfo.startx && scInfo.z1 == scInfo.startz1)
                            {
                                if (scInfo.y < scInfo.starty + scInfo.zth)
                                {
                                    scInfo.y++;
                                }
                                else if (scInfo.y == scInfo.starty + scInfo.zth)
                                {
                                    scInfo.taskstatus = 4;
                                }
                            }
                        }
                        else if (scInfo.taskstatus == 5)//放货行走
                        {
                            if (scInfo.y < scInfo.desty + scInfo.zth)
                            {
                                scInfo.y++;
                            }
                            else if (scInfo.y > scInfo.desty + scInfo.zth)
                            {
                                scInfo.y--;
                            }
                            if (scInfo.x == scInfo.destx && scInfo.y == scInfo.desty + scInfo.zth)
                            {
                                scInfo.taskstatus = 6;
                            }
                        }
                        else if (scInfo.taskstatus == 7)//放货伸叉后放下
                        {
                            if (scInfo.x == scInfo.destx && scInfo.z1 == scInfo.destz1)
                            {
                                if (scInfo.y > scInfo.desty)
                                {
                                    scInfo.y--;
                                }
                                else if (scInfo.y == scInfo.desty)
                                {
                                    scInfo.taskstatus = 8;
                                }
                            }
                        }
                    }
                    //obj.Message += string.Format("{0}号堆垛机仿真：x:{1};y:{2};z:{3};s:{4}。", scInfo.no, scInfo.x, scInfo.y, scInfo.z1, scInfo.taskstatus);
                }
                Thread.Sleep(500);
            }
        }

        private static void SyncSCz()
        {
            while (threadSCzGoon)
            {
                foreach (ScInfo scInfo in scInfos)
                {
                    if (new int[] { 1, 2, 3, 4 }.Contains(scInfo.no))
                    {
                        if (scInfo.taskstatus == 2)//取货伸叉
                        {
                            if (scInfo.x == scInfo.startx && scInfo.y == scInfo.starty)
                            {
                                if (scInfo.z1 < scInfo.startz1)
                                {
                                    scInfo.z1++;
                                }
                                else if (scInfo.z1 == scInfo.startz1)
                                {
                                    scInfo.taskstatus = 3;
                                }
                            }
                        }
                        else if (scInfo.taskstatus == 4)//取货收叉
                        {
                            if (scInfo.x == scInfo.startx && scInfo.y == scInfo.starty + scInfo.zth)
                            {
                                if (scInfo.z1 > 0)
                                {
                                    scInfo.z1--;
                                }
                                else if (scInfo.z1 == 0)
                                {
                                    scInfo.taskstatus = 5;
                                }
                            }
                        }
                        else if (scInfo.taskstatus == 6)//放货伸叉
                        {
                            if (scInfo.x == scInfo.destx && scInfo.y == scInfo.desty + scInfo.zth)
                            {
                                if (scInfo.z1 < scInfo.destz1)
                                {
                                    scInfo.z1++;
                                }
                                else if (scInfo.z1 == scInfo.destz1)
                                {
                                    scInfo.taskstatus = 7;
                                }
                            }
                        }
                        else if (scInfo.taskstatus == 8)//放货收叉
                        {
                            if (scInfo.x == scInfo.destx && scInfo.y == scInfo.desty)
                            {
                                if (scInfo.z1 > 0)
                                {
                                    scInfo.z1--;
                                }
                                else if (scInfo.z1 == 0)
                                {
                                    scInfo.taskstatus = 9;
                                }
                            }
                        }
                        else if (scInfo.taskstatus == 9)//放货收叉
                        {
                            Thread.Sleep(5000);
                            int s = scInfo.destx;
                            scInfo.destx = scInfo.startx;
                            scInfo.startx = s;
                            s = scInfo.desty;
                            scInfo.desty = scInfo.starty;
                            scInfo.starty = s;
                            s = scInfo.destz1;
                            scInfo.destz1 = scInfo.startz1;
                            scInfo.startz1 = s;
                            scInfo.taskstatus = 0;
                        }
                    }
                    //obj.Message += string.Format("{0}号堆垛机仿真：x:{1};y:{2};z:{3};s:{4}。", scInfo.no, scInfo.x, scInfo.y, scInfo.z1, scInfo.taskstatus);
                }
                Thread.Sleep(500);
            }
        }

        #endregion
    }
}
