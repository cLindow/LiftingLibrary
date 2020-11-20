<template>
  <div class="px-5">
  <div>
    <b-navbar toggleable="lg" type="dark" variant="dark">
      <b-navbar-brand href="#">Exercise Library</b-navbar-brand>

      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav>
          <b-nav-item href="#">Home</b-nav-item>
          <b-nav-item href="#">Videos</b-nav-item>
        </b-navbar-nav>

        <!-- Right aligned nav items -->
        <b-navbar-nav class="ml-auto">

          <content-creation-dialog></content-creation-dialog>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
  </div>

  <div>
    <Nuxt />
  </div>
  </div>
</template>

<script>
import ContentCreationDialog from "@/components/content-creation/content-creation-dialog";

export default {
  components: {
    ContentCreationDialog,
  }
}
</script>
