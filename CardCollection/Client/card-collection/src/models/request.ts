import { card } from "./card";
import { trade } from "./trade";

export interface Request {
    id: number,
    Trade: trade,
    RequestedCards: card[]
}