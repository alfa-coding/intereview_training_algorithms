using System;

namespace Algorithms.Library
{
    public class ChessProbability
    {
        
        private double[,,]board;
        private int[] dirCol;
        private int[] dirRow;
        private int n;
        
        public bool InRange(int f,int c)
        {
            return f>=0&&f<this.n&&c>=0&&c<this.n;
        }
        
        public double KnightProbability(int n, int k, int row, int column) {
            this.board  = new double[n,n,k+1];
            this.n=n;
                
            for(int i=0;i<n;i++)
                for(int j=0;j<n;j++)  
                    for(int p=0;p<=k;p++)
                        this.board[i,j,p]=0.0;
                
            this.dirCol= new int[]{-2,-1,1,2,2,1,-1,-2};
            this.dirRow= new int[]{-1,-2,-2,-1,1,2,2,1};
            return Probability(k,row,column);
        
            
        }
        
        public double Probability(int k, int row, int column)
        {
            if(k==0) return 1;
            
            if(board[row, column, k]!=0.0) return board[row, column, k];
            
            else
            {   
                double currentProbability=0;
                for(int i=0;i<dirRow.Length;i++)
                {
                    int nR= row + dirRow[i];
                    int nC= column + dirCol[i];
                    if(InRange(nR,nC))
                        currentProbability+=Probability(k-1,nR,nC);
                }
                
                board[row, column, k] = currentProbability / 8.0;
            
                return board[row, column, k];
            }
        }

        public double KnightProbabilityTabulation(int n, int k, int row, int column) {
        this.n=n;              
            
        this.dirCol= new int[]{-2,-1,1,2,2,1,-1,-2};
        this.dirRow= new int[]{-1,-2,-2,-1,1,2,2,1};
        this.board  = new double[k+1,n,n];
        board[0,row,column]=1;
        return ProbabilityTabulation(k);
    
        
    }
    
    public double ProbabilityTabulation(int k)
    {
        
        for(int veces =1;veces<=k;veces++)
        {
            
            double[,,]nextboard = new double[k+1,n,n];
            
        
            for(int i=0;i<n;i++)
            {
                for(int j=0;j<n;j++)
                {
                    for(int d=0;d<8;d++)
                    {
                        int nR= i + dirRow[d];
                        int nC= j + dirCol[d];
                        if(InRange(nR,nC)&&board[veces-1,nR,nC]!=0.0)
                        {
                            nextboard[veces,i,j]+=board[veces-1,nR,nC]/8;
                        }
                    }
                }
            }
            board = nextboard;
        }
        
        double response =0;
        
        for(int i=0;i<n;i++)
            for(int j=0;j<n;j++)
                response+=board[k,i,j];
        
        return response;
                
        
    }
    }
}