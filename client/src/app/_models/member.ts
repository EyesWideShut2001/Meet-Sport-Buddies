import { Photo } from "./Photo"
import { Sport } from "./Sport"

export interface Member {
    id: number
    username: string
    age: number
    photoUrl: string
    knownAs: string
    created: Date
    lastActive: Date
    gender: string
    introduction: string
    sports: Sport[]
    city: string
    country: string
    photos: Photo[]
  }
  

