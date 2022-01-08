using UnityEngine;

public class KeyboardConfiguration : MonoBehaviour
{

    #region Public variables
    
    public ApplicationManager applicationManager;

    #endregion

    #region Monobehaviour Callbacks (update)

    private void Update()
    {
        ConfigureKeyControls();
    }

    #endregion

    #region Custom functions (to configure key controls)

    private void ConfigureKeyControls()
    {
        #region Application Close
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
        #endregion

        #region Light Animations

        if (applicationManager.stage1.activeSelf)// || applicationManager.stage2.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                applicationManager.lightController.PlayLightAnimation("Moving Lights Color");
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                applicationManager.lightController.PlayLightAnimation("Moving Lights White");
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                applicationManager.lightController.PlayLightAnimation("Static Lights Fluid");
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                applicationManager.lightController.PlayLightAnimation("Static Lights Spot");
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                applicationManager.lightController.PlayLightAnimation("Truss Light White");
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                applicationManager.lightController.PlayLightAnimation("Truss Light Yellow");
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                applicationManager.lightController.PlayLightAnimation("Truss Light Red");
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                applicationManager.lightController.PlayLightAnimation("Truss Light Pink");
            }
            else if (Input.GetKeyDown(KeyCode.I))
            {
                applicationManager.lightController.PlayLightAnimation("Truss Light Green");
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                applicationManager.lightController.PlayLightAnimation("Truss Light Orange");
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                applicationManager.lightController.PlayLightAnimation("Truss Light Purple");
            }
        }

        #endregion

        #region Camera Animations
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            applicationManager.cameraController.PlayCameraAnimations("base_movement");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (applicationManager.stage1.activeSelf)
            {
                applicationManager.cameraController.PlayCameraAnimations("camera_look_around");
            }
            else if (applicationManager.stage2.activeSelf)
            {
                applicationManager.cameraController.PlayCameraAnimations("camera_pan_right_2");
            }
            else if (applicationManager.stage3.activeSelf)
            {
                applicationManager.cameraController.PlayCameraAnimations("full_stage_cover");
            }
            else if (applicationManager.stage4.activeSelf)
            {
                applicationManager.cameraController.PlayCameraAnimations("zoom_out_full_stage");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (applicationManager.stage1.activeSelf)
            {
                applicationManager.cameraController.PlayCameraAnimations("camera_pan_right");
            }
            else if (applicationManager.stage2.activeSelf)
            {
                applicationManager.cameraController.PlayCameraAnimations("camera_pan_left_2");
            }
            else if (applicationManager.stage3.activeSelf)
            {
                applicationManager.cameraController.PlayCameraAnimations("camera_two_screens");
            }
            else if (applicationManager.stage4.activeSelf)
            {
                applicationManager.cameraController.PlayCameraAnimations("center_left");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (applicationManager.stage1.activeSelf)
            {
                applicationManager.cameraController.PlayCameraAnimations("camera_pan_left");
            }
            else if (applicationManager.stage2.activeSelf)
            {
                applicationManager.cameraController.PlayCameraAnimations("camera_zoom_center_only_2");
            }
            else if (applicationManager.stage3.activeSelf)
            {
                applicationManager.cameraController.PlayCameraAnimations("camera_left_screen");
            }
            else if (applicationManager.stage4.activeSelf)
            {
                applicationManager.cameraController.PlayCameraAnimations("center_right");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (applicationManager.stage1.activeSelf)
            {
                applicationManager.cameraController.PlayCameraAnimations("camera_zoom_center_only");
            }
            else if (applicationManager.stage2.activeSelf)
            {
                applicationManager.cameraController.PlayCameraAnimations("left_right_center_areal_zoom_2");
            }
            else if (applicationManager.stage3.activeSelf)
            {
                applicationManager.cameraController.PlayCameraAnimations("camera_right_screen");
            }
            else if (applicationManager.stage4.activeSelf)
            {
                applicationManager.cameraController.PlayCameraAnimations("center_only");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (applicationManager.stage1.activeSelf)
            {
                applicationManager.cameraController.PlayCameraAnimations("left_right_center_areal_zoom");
            }
            else if (applicationManager.stage2.activeSelf)
            {
                applicationManager.cameraController.PlayCameraAnimations("camera_zoom_left_only_2");
            }
            else if (applicationManager.stage4.activeSelf)
            {
                applicationManager.cameraController.PlayCameraAnimations("on_lights_focus_curve");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (applicationManager.stage1.activeSelf)
            {
                applicationManager.cameraController.PlayCameraAnimations("camera_zoom_left_only");
            }
            else if (applicationManager.stage2.activeSelf)
            {
                applicationManager.cameraController.PlayCameraAnimations("camera_zoom_right_only_2");
            }
            else if (applicationManager.stage4.activeSelf)
            {
                applicationManager.cameraController.PlayCameraAnimations("zoom_curve_center_back");
            }

        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            if (applicationManager.stage1.activeSelf)
            {
                applicationManager.cameraController.PlayCameraAnimations("camera_zoom_right_only");
            }
        }

        #endregion

        #region Stage Change

        if (Input.GetKeyDown(KeyCode.F1))
        {
            applicationManager.stageController.ControlStage(applicationManager.stage1, "F1");
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            applicationManager.stageController.ControlStage(applicationManager.stage2, "F2");
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            applicationManager.stageController.ControlStage(applicationManager.stage3, "F3");
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            applicationManager.stageController.ControlStage(applicationManager.stage4, "F4");
        }

        #endregion

        #region Raybot Sequence

        if (applicationManager.stage1.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                applicationManager.raybotSequence.ControlRaybotEntry();
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                applicationManager.raybotSequence.ControlRaybotExit();
            }
        }

        #endregion

        #region 3rd / 4th Stage Tint Color

        if (applicationManager.stage3.activeSelf || applicationManager.stage4.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                applicationManager.stageController.ChangeStageTint(Color.red);
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                applicationManager.stageController.ChangeStageTint(Color.green);
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                applicationManager.stageController.ChangeStageTint(Color.blue);
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                applicationManager.stageController.ChangeStageTint(Color.cyan);
            }
            else if (Input.GetKeyDown(KeyCode.M))
            {
                applicationManager.stageController.ChangeStageTint(Color.magenta);
            }
            else if (Input.GetKeyDown(KeyCode.Y))
            {
                applicationManager.stageController.ChangeStageTint(Color.yellow);
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                applicationManager.stageController.ChangeStageTint(Color.black);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                applicationManager.stageController.ChangeStageTint(Color.white);
            }
        }

        #endregion

        #region Emcee
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            applicationManager.emceeController.ControlEmcee();
        }

        #endregion

        #region Objects (car/laptop)

        if (applicationManager.stage1.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                applicationManager.carController.ControlCar();
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                applicationManager.laptopController.ControlLaptop();
            }
        }

        #endregion
    }

    #endregion

}
