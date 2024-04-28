export const useRollDice = () => {
  const rollDice = () => {
    return Math.floor(Math.random() * 6) + 1
  }

  return { rollDice }
}
