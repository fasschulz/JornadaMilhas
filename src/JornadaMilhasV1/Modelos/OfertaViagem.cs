﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JornadaMilhasV1.Validador;

namespace JornadaMilhasV1.Modelos;

public class OfertaViagem: Valida
{
    public const double DESCONTO_MAXIMO = 0.7;
    private double desconto;

    public int Id { get; set; }
    public Rota Rota { get; set; } 
    public Periodo Periodo { get; set; }
    public double Preco { get; set; }
    public double Desconto {
        get => desconto;
        set 
        { 
            desconto = value;

            if (desconto >= Preco)
                Preco *= (1 - DESCONTO_MAXIMO);
            else if (!double.IsNegative(desconto))
                Preco -= desconto;
        }
    }
    public bool Ativa { get; set; }


    public OfertaViagem(Rota rota, Periodo periodo, double preco, bool ativa = true)
    {
        Rota = rota;
        Periodo = periodo;       
        Preco = preco;
        Ativa = ativa;
        Validar();
    }

    public override string ToString()
    {
        return $"Origem: {Rota.Origem}, Destino: {Rota.Destino}, Data de Ida: {Periodo.DataInicial.ToShortDateString()}, Data de Volta: {Periodo.DataFinal.ToShortDateString()}, Preço: {Preco:C}";
    }

    protected override void Validar()
    {
        if(Ativa is false)
            Erros.RegistrarErro("A oferta de viagem está inativa.");

        if (Rota == null || Periodo == null)
        {
            Erros.RegistrarErro("A oferta de viagem não possui rota ou período válidos.");
        }
        else if (!Periodo.EhValido)
        {
            Erros.RegistrarErro(Periodo.Erros.Sumario);
        }
        else if (!Rota.EhValido)
        {
            Erros.RegistrarErro(Rota.Erros.Sumario);
        }        
        else if (Preco <= 0)
        {
            Erros.RegistrarErro("O preço da oferta de viagem deve ser maior que zero.");
        }
    }
}
