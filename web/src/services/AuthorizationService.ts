import { postJson } from "@/utils/fetch"


export const Token = (input: any) => {
    return postJson("/api/v1/auth/token", input)
}