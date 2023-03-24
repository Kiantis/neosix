using FrooxEngine;
using HarmonyLib;
using NeosModLoader;
using System;
using Wasmtime;

namespace neosix {

  public class Mod : NeosMod {
    public override string Name => "neosix";
    public override string Author => "Kiantis";
    public override string Version => "1.0.0";
    public override string Link => "https://github.com/Kiantis/neosix";

    public override void OnEngineInit() {
      Msg("neosix: pre-patch");

      TestWASM();

      var harmony = new Harmony(Author + "-" + Name + "-" + Version);
      FrooxEngine.Engine.Current.RunPostInit(OnEngineInitialized);

      Msg("neosix: post-patch");
    }

    public void OnEngineInitialized() {
      Msg("neosix: pre-register");
      
      WorkerInitializer.ComponentLibrary.GetSubcategory("WASM").AddElement(typeof(BaseWASM));
      
      Msg("neosix: post-register");
    }

    public void TestWASM() {
      var engine = new Wasmtime.Engine();

      var module = Module.FromText(
          engine,
          "hello",
          "(module (func $hello (import \"\" \"hello\")) (func (export \"run\") (call $hello)))"
      );

      var linker = new Linker(engine);
      var store = new Store(engine);

      linker.Define(
          "",
          "hello",
          Function.FromCallback(store, () => Msg("neosix wasm round trip test: Hello from WASM!"))
      );

      var instance = linker.Instantiate(store, module);
      var run = instance.GetAction("run")!;
      run();
    }
  }
}
