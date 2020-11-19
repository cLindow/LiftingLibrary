const initState = () => ({
  uploadPromise: null,
  active: false,
  type: "",
  tabIndex: 0
});



export const state = initState;

export const mutations = {
  toggleActive(state) {
    state.active = !state.active
    if(!state.active){
      Object.assign(state, initState())
    }
  },
  setType(state, {type}) {
    state.type = type
    state.tabIndex++
  },
  setTask(state, {uploadPromise}){
    state.uploadPromise = uploadPromise;
    state.tabIndex++
  },
  reset(state){
    Object.assign(state,initState())
  }
}

export const actions = {
  startVideoUpload({commit, dispatch}, {form}){
    const uploadPromise = this.$axios.$post("/api/videos", form);
    commit("setTask", {uploadPromise})
  },
  async createExercise({commit, dispatch}, {exercise}){
    await this.$axios.$post("/api/exercises", exercise)
    await dispatch('exercises/fetchExercises')
  }
}
