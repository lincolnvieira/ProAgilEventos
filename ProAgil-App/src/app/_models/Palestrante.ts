import { RedeSocial } from "./RedeSocial";
import { Evento } from "./Evento";

export interface Palestrante {
    palestranteId: number; 
    nome: string; 
    miniCurriculo: string; 
    imagemUrl: string; 
    telefone: string; 
    email: string; 

    redeSociais: RedeSocial []; 
    palestranteEventos: Evento[]; 
}
