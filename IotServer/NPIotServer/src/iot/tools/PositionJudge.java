package iot.tools;

import iot.pojo.Position;
import iot.pojo.RingRecord;

public class PositionJudge {
    private Position position;
    private Position[] polygon;
    
    public PositionJudge(RingRecord record) {
        position = record.getPosition();
        polygon = getPolygon(record.getId());
    }
    
    //TODO 实现
    private Position[] getPolygon(int elderId) {
        return new Position[3];
    }
    
    public boolean judge() {
        return isPointInPoly(position, polygon);
    }
    
  //TODO 优化
    private boolean isPointInPoly(Position point, Position[] polygon) {
        int N = polygon.length;
        boolean boundOrVertex = true; //如果点位于多边形的顶点或边上，也算做点在多边形内，直接返回true
        int intersectCount = 0;//cross points count of x 
        float precision = (float) 2e-10; //浮点类型计算时候与0比较时候的容差
        Position p1, p2;//neighbour bound vertices
        Position p = point; //测试点
        p1=polygon[0];      //left vertex
        for(int i=1;i<=N;++i) {
            if(p.equals(p1)) {
                return boundOrVertex;
            }
            p2 = polygon[i % N];//right vertex            
            if(p.getLat() < Math.min(p1.getLat(), p2.getLat()) || p.getLat() > Math.max(p1.getLat(), p2.getLat())){//ray is outside of our interests                
                p1 = p2; 
                continue;//next ray left point
            }
            if(p.getLat() > Math.min(p1.getLat(), p2.getLat()) && p.getLat() < Math.max(p1.getLat(), p2.getLat())){//ray is crossing over by the algorithm (common part of)
                if(p.getLng() <= Math.max(p1.getLng(), p2.getLng())){//x is before of ray                    
                    if(p1.getLat() == p2.getLat() && p.getLng() >= Math.min(p1.getLng(), p2.getLng())){//overlies on a horizontal ray
                        return boundOrVertex;
                    }
                    if(p1.getLng() == p2.getLng()){//ray is vertical                        
                        if(p1.getLng() == p.getLng()){//overlies on a vertical ray
                            return boundOrVertex;
                        }else{//before ray
                            ++intersectCount;
                        } 
                    }else{//cross point on the left side                        
                        double xinters = ((p.getLat() - p1.getLat()) * (p2.getLng() - p1.getLng()) / (p2.getLat() - p1.getLat()) + p1.getLng());//cross point of getLng()                        
                        if(Math.abs(p.getLng() - xinters) < precision){//overlies on a ray
                            return boundOrVertex;
                        }
                        if(p.getLng() < xinters){//before ray
                            ++intersectCount;
                        } 
                    }
                }
            }else{//special case when ray is crossing through the vertex                
                if(p.getLat() == p2.getLat() && p.getLng() <= p2.getLng()){//p crossing over p2                    
                    Position p3 = polygon[(i+1) % N]; //next vertex                    
                    if(p.getLat() >= Math.min(p1.getLat(), p3.getLat()) && p.getLat() <= Math.max(p1.getLat(), p3.getLat())){//p.getLat() lies between p1.getLat() & p3.getLat()
                        ++intersectCount;
                    }else{
                        intersectCount += 2;
                    }
                }
            }            
            p1 = p2;//next ray left point
        }
        if(intersectCount % 2 == 0){//偶数在多边形外
            return false;
        } else { //奇数在多边形内
            return true;
        }       
    }
    
}
