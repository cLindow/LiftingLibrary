<template>
  <div>
    <template>
      <b-nav-form>
        <b-nav-item-dropdown text="Upload" right>
          <b-dropdown-item v-for="(item,index) in menuItems"
                           :key="`ccd-menu-${index}`"
                           @click="activate({component: item.component})">
            {{item.title}}
          </b-dropdown-item>
        </b-nav-item-dropdown>
      </b-nav-form>
    </template>
  <b-modal :visible="active" size="lg" no-close-on-backdrop hide-footer>
  <div v-if="component">
    <component :is="component"></component>
  </div>
    <div>
      <b-btn @click="reset">
        reset
      </b-btn>
    </div>
  </b-modal>
  </div>
</template>

<script>
import {mapState, mapMutations} from "vuex";
import ExerciseSteps from "@/components/content-creation/exercise-steps";
import SubmissionSteps from "@/components/content-creation/submissions-steps"
import CategoryForm from "@/components/content-creation/category-form";
import DifficultyForm from "@/components/content-creation/difficulty-form";

export default {
  name: "content-creation-dialog",
  components: {DifficultyForm, CategoryForm, ExerciseSteps, SubmissionSteps},
  computed:
    {
      ...mapState("video-upload", ["active", "component"]),
      menuItems() {
      return [
       {component: ExerciseSteps, title: "Exercise"},
       {component: SubmissionSteps, title: "Submission"},
        {component: CategoryForm, title: "Category"},
        {component: DifficultyForm, title: "Difficulty"},
      ]
      }
},
  methods: mapMutations("video-upload", ["reset", "activate"])
  }
</script>


<style scoped>

</style>
