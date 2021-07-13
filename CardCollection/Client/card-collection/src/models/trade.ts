import { User } from "src/models/user"
import { card } from "./card";

export interface trade {
    id: number,
    user: User,
    cards: card[],
}