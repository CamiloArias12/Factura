import { apiGet } from "./api";
import { Bill, Client } from "../utils/types";

export async function billAllGetService(): Promise<Bill[]| null> {
    return await apiGet<Bill[]>("/api/bill",);
}
export async function clientAllGetService(): Promise<Client[]| null> {
    return await apiGet<Client[]>("/api/client",);
}
