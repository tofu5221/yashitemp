using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiSha.Business.BinfoManage;
using YiSha.Util;
using YiSha.Util.Model;
using YiSha.Model.Result;

namespace YiSha.Business.AutoJob
{
    public class ScSimulationJob : IJobTask
    {
        public async Task<TData> Start()
        {
            TData obj = new TData();

            foreach (ScInfo scInfo in ScBLL.scInfos)
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
                    else if (scInfo.taskstatus == 2)//取货伸叉
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
                }
                obj.Message += string.Format("{0}号堆垛机仿真：x:{1};y:{2};z:{3};s:{4}。", scInfo.no, scInfo.x, scInfo.y, scInfo.z1, scInfo.taskstatus);
            }
            
            obj.Tag = 1;
            //obj.Message = "堆垛机仿真：" + info;
            return obj;
        }
    }
}
