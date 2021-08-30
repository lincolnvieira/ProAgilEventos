import { Lote } from "./Lote";
import { RedeSocial } from "./RedeSocial";
import { Palestrante } from "./Palestrante";

export interface Evento {
     eventoId: number; 
     local: string;
     dataEvento: Date;
     tema: string;  
     qtdPessoas: number;
     telefone: string;
     email: string;
     imagemUrl: string;  
     lotes: Lote[];  
     redeSociais: RedeSocial[];  

     palestranteEventos: Palestrante[];  
}
