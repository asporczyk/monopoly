interface Player {
  id: string
  nickname: string
  money: number
  color?: string
  position: number
  isActivePlayer?: boolean
  isBankrupt?: boolean
  isInJail?: boolean
  isReady?: boolean
  jailTurns?: number
}
