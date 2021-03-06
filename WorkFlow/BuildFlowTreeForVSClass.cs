﻿//******************************************************************************//
// Copyright 2013 Moein Ghasemzadeh and Benjamin C. M. Fung                     //
//                                                                              //
// Licensed under the Apache License, Version 2.0 (the "License");              //
// you may not use this file except in compliance with the License.             //
// You may obtain a copy of the License at                                      //
//                                                                              //
//      http://www.apache.org/licenses/LICENSE-2.0                              //
//                                                                              //
// Unless required by applicable law or agreed to in writing, software          //
// distributed under the License is distributed on an "AS IS" BASIS,            //
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.     //
// See the License for the specific language governing permissions and          //
// limitations under the License.                                               //
//******************************************************************************//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkFlow
{
    class BuildFlowTreeForVSClass
    {
        public LTPairs BuildFlowTreeForVSF(List<List<LTClass>> TpMinusTm)
        {
            LTPairs rootNode = new LTPairs(0, 0, 0, null, null);
            int i = 0;
            LTPairs tempNode = rootNode;
            foreach (List<LTClass> temp in TpMinusTm)
            {
                foreach (LTClass temp2 in temp)
                {
                    if (temp2 == temp[0])
                    {
                        i = 0;
                        tempNode = rootNode;
                        foreach (LTPairs tempNode2 in tempNode.next)
                        {
                            if (tempNode2 != null)
                                if (tempNode.next[i].location != temp2.location || tempNode.next[i].time != temp2.time)
                                {
                                    i++;
                                }
                                else
                                {
                                    break;
                                }
                        }
                        if (tempNode.next.Count == i)
                            tempNode.next.Add(null);
                        if (tempNode.next[i] == null)
                        {
                            tempNode.next[i] = new LTPairs(temp2.location, temp2.time, 1, null, tempNode);
                        }
                        else
                        {
                            tempNode.next[i].counter++;
                        }
                        tempNode = tempNode.next[i];
                    }
                    else
                    {
                        i = 0;
                        foreach (LTPairs tempNode2 in tempNode.next)
                        {
                            if (tempNode2 != null)
                                if (tempNode.next[i].location != temp2.location || tempNode.next[i].time != temp2.time)
                                {
                                    i++;
                                }
                                else
                                {
                                    break;
                                }
                        }
                        if (tempNode.next.Count == i)
                            tempNode.next.Add(null);
                        if (tempNode.next[i] == null)
                        {
                            tempNode.next[i] = new LTPairs(temp2.location, temp2.time, 1, null, tempNode);
                        }
                        else
                        {
                            tempNode.next[i].counter++;
                        }
                        tempNode = tempNode.next[i];
                    }
                }
            }
            return rootNode;
        }
    }
}
