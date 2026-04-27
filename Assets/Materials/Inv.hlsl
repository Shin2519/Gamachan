#ifndef HITMASK_INCLUDED

#define HITMASK_INCLUDED

float4 _Hitpositions[32];

float _Hitcount;

void HitMask_float(float3 WorldPos,float Radius,float Softness,out float Mask)
{
    float result = 0;
    for (int i = 0; i < (int) _Hitcount;i++)
    {
        float d = distance(WorldPos,_Hitpositions[i].xyz);
        
        float a = 1 - smoothstep(Radius - Softness, Radius, d);
        
        result = max(result,a * _Hitpositions[i].w);
    }
    Mask = saturate(result);
}

#endif