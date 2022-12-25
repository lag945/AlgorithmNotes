﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class UnionFind
{
    private int[] root;
    private int[] rank;
    public UnionFind(int n)
    {
        this.root = new int[n];
        this.rank = new int[n];
        for (int i = 0; i < n; ++i)
        {
            this.root[i] = i;
            this.rank[i] = 1;
        }
    }
    public int find(int x)
    {
        if (this.root[x] != x)
        {
            this.root[x] = find(this.root[x]);
        }
        return this.root[x];
    }
    public void union(int x, int y)
    {
        int rootX = find(x), rootY = find(y);
        if (rootX != rootY)
        {
            if (this.rank[rootX] > this.rank[rootY])
            {
                int tmp = rootX;
                rootX = rootY;
                rootY = tmp;
            }
            // Modify the root of the smaller group as the root of the
            // larger group, also increment the size of the larger group.
            this.root[rootX] = rootY;
            this.rank[rootY] += this.rank[rootX];
        }
    }

    public void unUnion(int x, int y)
    {
        int rootX = find(x), rootY = find(y);
        if (rootX == rootY)
        {
            if (this.rank[rootX] > this.rank[rootY])
            {
                int tmp = rootX;
                rootX = rootY;
                rootY = tmp;
            }
            // Modify the root of the smaller group as the root of the
            // larger group, also increment the size of the larger group.
            this.root[rootX] = rootY;
            this.rank[rootY] += this.rank[rootX];
        }
    }

}