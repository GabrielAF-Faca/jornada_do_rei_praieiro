

using System;

public class JogadorPontos : IComparable<JogadorPontos>
{
    public string nome;
    public int pontos;

    public int CompareTo(JogadorPontos other)
    {
        if (other == null) return 1;

        JogadorPontos o = other as JogadorPontos;
        if (o != null) 
        {
            return o.pontos.CompareTo(this.pontos);
        }
            
        return 1;
    }

    public override string ToString()
    {
        return nome + " - " + pontos;
    }

}
