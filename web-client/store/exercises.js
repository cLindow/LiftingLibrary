const initState = () => ({
  exercises: []
});

export const state = initState;

export const getters = {
  exerciseItems: state => state.exercises.map(x => ({
    text: x.name,
    value: x.id
  }))
}

export const mutations = {
  setExercises(state, {exercises}){
    state.exercises = exercises;
  },
  reset(state){
    Object.assign(state,initState())
  }
}

export const actions = {
  async fetchExercises({commit}){
    const exercises =  await this.$axios.$get("/api/exercises")
    commit("setExercises", {exercises});
  },
  createExercise({state, commit, dispatch}, {form}){
    return this.$axios.$post("/api/exercises", form)
  }
}
