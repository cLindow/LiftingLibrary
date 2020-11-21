const initState = () => ({
  exercises: [],
  categories: [],
  difficulties: [],
});

export const state = initState;

export const getters = {
  exerciseById: state => id => state.exercises.find(x => x.id === id),
  exerciseItems: state => state.exercises.map(x => ({
    text: x.name,
    value: x.id
  })),
  difficultyItems: state => state.difficulties.map(x => ({
    text: x.name,
    value: x.id
  })),
  categoryItems: state => state.categories.map(x => ({
    text: x.name,
    value: x.id
  }))
}

export const mutations = {
  setExercises(state, {exercises, difficulties, categories}){
    state.exercises = exercises;
    state.difficulties = difficulties;
    state.categories = categories;
  },
  reset(state){
    Object.assign(state,initState())
  }
}

export const actions = {
  async fetchExercises({commit}){
    const exercises =  await this.$axios.$get("/api/exercises")
    const categories =  await this.$axios.$get("/api/categories")
    const difficulties =  await this.$axios.$get("/api/difficulties")

    commit("setExercises", {exercises, categories, difficulties});
  },
  createExercise({state, commit, dispatch}, {form}){
    return this.$axios.$post("/api/exercises", form)
  }
}
