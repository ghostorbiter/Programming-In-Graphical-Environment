// lab1.cpp : Defines the entry point for the application.
//

#include "framework.h"
#include "lab1.h"

#define MAX_LOADSTRING 100

// Global Variables:
HINSTANCE hInst;                                // current instance
WCHAR szTitle[MAX_LOADSTRING];                  // The title bar text
WCHAR szWindowClass[MAX_LOADSTRING];            // the main window class name

// Forward declarations of functions included in this code module:
ATOM                MyRegisterClass(HINSTANCE hInstance);
ATOM MyRegisterClassBall(HINSTANCE hInstance);
ATOM MyRegisterClassPaddle(HINSTANCE hInstance);
BOOL                InitInstance(HINSTANCE, int);
LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);
LRESULT CALLBACK WndProcBall(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam);
LRESULT CALLBACK WndProcPaddle(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam);
INT_PTR CALLBACK    About(HWND, UINT, WPARAM, LPARAM);

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
                     _In_opt_ HINSTANCE hPrevInstance,
                     _In_ LPWSTR    lpCmdLine,
                     _In_ int       nCmdShow)
{
    UNREFERENCED_PARAMETER(hPrevInstance);
    UNREFERENCED_PARAMETER(lpCmdLine);

    // TODO: Place code here.

    // Initialize global strings
    LoadStringW(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
    LoadStringW(hInstance, IDC_LAB1, szWindowClass, MAX_LOADSTRING);
    MyRegisterClass(hInstance);
    MyRegisterClassBall(hInstance);
    MyRegisterClassPaddle(hInstance);

    // Perform application initialization:
    if (!InitInstance (hInstance, nCmdShow))
    {
        return FALSE;
    }

    HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_LAB1));

    MSG msg;

    // Main message loop:
    while (GetMessage(&msg, nullptr, 0, 0))
    {
        if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
        {
            TranslateMessage(&msg);
            DispatchMessage(&msg);
        }
    }

    return (int) msg.wParam;
}



//
//  FUNCTION: MyRegisterClass()
//
//  PURPOSE: Registers the window class.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
    WNDCLASSEXW wcex;

    wcex.cbSize = sizeof(WNDCLASSEX);

    wcex.style          = CS_HREDRAW | CS_VREDRAW;
    wcex.lpfnWndProc    = WndProc;
    wcex.cbClsExtra     = 0;
    wcex.cbWndExtra     = 0;
    wcex.hInstance      = hInstance;
    wcex.hIcon          = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_LAB1));
    wcex.hCursor        = LoadCursor(nullptr, IDC_ARROW);
    wcex.hbrBackground  = (HBRUSH)(COLOR_WINDOW+1);
    wcex.lpszMenuName   = MAKEINTRESOURCEW(IDC_LAB1);
    wcex.lpszClassName  = szWindowClass;
    wcex.hIconSm        = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

    return RegisterClassExW(&wcex);
}

ATOM MyRegisterClassBall (HINSTANCE hInstance)
{
    WNDCLASSEXW wcex;

    wcex.cbSize = sizeof(WNDCLASSEX);

    wcex.style = CS_HREDRAW | CS_VREDRAW;
    wcex.lpfnWndProc = WndProcBall;
    wcex.cbClsExtra = 0;
    wcex.cbWndExtra = 0;
    wcex.hInstance = hInstance;
    wcex.hIcon = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_LAB1));
    wcex.hCursor = LoadCursor(nullptr, IDC_ARROW);
    wcex.hbrBackground = (HBRUSH)(CreateSolidBrush(RGB(255, 0, 0)));
    wcex.lpszMenuName = MAKEINTRESOURCEW(IDC_LAB1);
    wcex.lpszClassName = L"Ball";
    wcex.hIconSm = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

    return RegisterClassExW(&wcex);
}

ATOM MyRegisterClassPaddle(HINSTANCE hInstance)
{
    WNDCLASSEXW wcex;

    wcex.cbSize = sizeof(WNDCLASSEX);

    wcex.style = CS_HREDRAW | CS_VREDRAW;
    wcex.lpfnWndProc = WndProcPaddle;
    wcex.cbClsExtra = 0;
    wcex.cbWndExtra = 0;
    wcex.hInstance = hInstance;
    wcex.hIcon = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_LAB1));
    wcex.hCursor = LoadCursor(nullptr, IDC_ARROW);
    wcex.hbrBackground = (HBRUSH)(CreateSolidBrush(RGB(150, 150, 150)));
    wcex.lpszMenuName = MAKEINTRESOURCEW(IDC_LAB1);
    wcex.lpszClassName = L"Paddle";
    wcex.hIconSm = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

    return RegisterClassExW(&wcex);
}

//
//   FUNCTION: InitInstance(HINSTANCE, int)
//
//   PURPOSE: Saves instance handle and creates main window
//
//   COMMENTS:
//
//        In this function, we save the instance handle in a global variable and
//        create and display the main program window.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   hInst = hInstance; // Store instance handle in our global variable

   HWND hWnd = CreateWindowW(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
      CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, nullptr, nullptr, hInstance, nullptr);

   if (!hWnd)
   {
      return FALSE;
   }

   SetWindowLong(hWnd, GWL_EXSTYLE, GetWindowLong(hWnd, GWL_EXSTYLE) | WS_EX_LAYERED);
   SetLayeredWindowAttributes(hWnd, 0, (255 * 80) / 100, LWA_ALPHA);

   RECT rc;
   GetWindowRect(hWnd, &rc);
   int x = GetSystemMetrics(SM_CXSCREEN);
   int y = GetSystemMetrics(SM_CYSCREEN);
   x = (x - rc.right) / 2;
   y = (y - rc.bottom) / 2;


   ///ball

   HWND hWndBall = CreateWindow(L"Ball", L"Ball", WS_CHILD | WS_VISIBLE,
       0, 0, 15, 15, hWnd, nullptr, hInstance, nullptr);

   if (!hWndBall)
   {
       return FALSE;
   }

   SetWindowLong(hWndBall, GWL_EXSTYLE, GetWindowLong(hWndBall, GWL_EXSTYLE) | WS_EX_LAYERED);
   SetLayeredWindowAttributes(hWndBall, 0, (255 * 80) / 100, LWA_ALPHA);

   //paddle
   RECT client;
   GetClientRect(hWnd, &client);
   HWND hWndPaddle = CreateWindow(L"Paddle", L"Paddle", WS_CHILD | WS_VISIBLE,
       0, client.bottom, 80, 20, hWnd, nullptr, hInstance, nullptr);

   if (!hWndPaddle)
   {
       return FALSE;
   }

   SetWindowLong(hWndPaddle, GWL_EXSTYLE, GetWindowLong(hWndPaddle, GWL_EXSTYLE) | WS_EX_LAYERED);
   SetLayeredWindowAttributes(hWndPaddle, 0, (255 * 80) / 100, LWA_ALPHA);

   ShowWindow(hWnd, nCmdShow);
   ShowWindow(hWndBall, nCmdShow);
   ShowWindow(hWndPaddle, nCmdShow);
   UpdateWindow(hWnd);
   MoveWindow(hWnd, x, y, 0, 0, false);
   UpdateWindow(hWndBall);
   UpdateWindow(hWndPaddle);


   return TRUE;
}

//
//  FUNCTION: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  PURPOSE: Processes messages for the main window.
//
//  WM_COMMAND  - process the application menu
//  WM_PAINT    - Paint the main window
//  WM_DESTROY  - post a quit message and return
//
//

static int paddleX = 0;

LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    switch (message)
    {
    case WM_COMMAND:
        {
            int wmId = LOWORD(wParam);
            // Parse the menu selections:
            switch (wmId)
            {
            case IDM_ABOUT:
                DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
                break;
            case IDM_EXIT:
                DestroyWindow(hWnd);
                break;
            default:
                return DefWindowProc(hWnd, message, wParam, lParam);
            }
        }
        break;
    case WM_CREATE:
    {
        HBRUSH brush = CreateSolidBrush(RGB(255, 255, 0));
        SetClassLongPtr(hWnd, GCLP_HBRBACKGROUND, (LONG_PTR)brush);
        break;
    }
    break;
    case WM_PAINT:
        {
            PAINTSTRUCT ps;
            HDC hdc = BeginPaint(hWnd, &ps);
            // TODO: Add any drawing code that uses hdc here...

            EndPaint(hWnd, &ps);
        }
        break;
    case WM_GETMINMAXINFO:
    {
        MINMAXINFO * minMaxInfo = (MINMAXINFO*)lParam;
        minMaxInfo->ptMaxSize.x = minMaxInfo->ptMaxTrackSize.x = 200;
        minMaxInfo->ptMaxSize.y = minMaxInfo->ptMaxTrackSize.y = 300;
        minMaxInfo->ptMinTrackSize.x = 200;
        minMaxInfo->ptMinTrackSize.y = 300;
    }
    break;
    case WM_DESTROY:
        PostQuitMessage(0);
        break;
    default:
        return DefWindowProc(hWnd, message, wParam, lParam);
    }
    return 0;
}

LRESULT CALLBACK WndProcBall(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    static int x = 0, y = 0;
    static int stepx = 3, stepy = 3;
    

    switch (message)
    {
    case WM_COMMAND:
    {
        int wmId = LOWORD(wParam);
        // Parse the menu selections:
        switch (wmId)
        {
        case IDM_ABOUT:
            DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
            break;
        case IDM_EXIT:
            DestroyWindow(hWnd);
            break;
        default:
            return DefWindowProc(hWnd, message, wParam, lParam);
        }
    }
    break;
    case WM_CREATE:
    {
        HRGN region = CreateEllipticRgn(0, 0, 15, 15);
        SetWindowRgn(hWnd, region, true);

        SetTimer(hWnd, 8, 50, NULL);
    }
    break;
    case WM_TIMER:
    {
        if (wParam == 8)
        {
            RECT rt;

            GetClientRect(GetParent(hWnd), &rt);
            if (x + 15 >= rt.right) stepx = -abs(stepx);
            if (x < 0) stepx = abs(stepx);
            if (y + 15 >= rt.bottom - 20)
            {
                if (paddleX == 0)
                {
                    if (x >= 0 && x <= 80)  stepy = -abs(stepy);
                    else KillTimer(hWnd, 8);
                }
                else if (paddleX == rt.right - 80)
                {
                    if (x >= rt.right - 80 && x <= rt.right) stepy = -abs(stepy);
                    else KillTimer(hWnd, 8);
                }
                else
                {
                    if (x >= paddleX - 10 && x <= paddleX + 80) stepy = -abs(stepy);
                    else KillTimer(hWnd, 8);
                }
            }
            if (y < 0) stepy = abs(stepy);
            MoveWindow(hWnd, x += stepx, y += stepy, 15, 15, true);
        }
    }
    break;
    case WM_PAINT:
    {
        PAINTSTRUCT ps;
        HDC hdc = BeginPaint(hWnd, &ps);
        // TODO: Add any drawing code that uses hdc here...

        EndPaint(hWnd, &ps);
    }
    break;
    case WM_GETMINMAXINFO:
    {
        MINMAXINFO* minMaxInfo = (MINMAXINFO*)lParam;
        minMaxInfo->ptMaxSize.x = minMaxInfo->ptMaxTrackSize.x = 15;
        minMaxInfo->ptMaxSize.y = minMaxInfo->ptMaxTrackSize.y = 15;
        minMaxInfo->ptMinTrackSize.x = 15;
        minMaxInfo->ptMinTrackSize.y = 15;
    }
    break;
    case WM_DESTROY:
        PostQuitMessage(0);
        break;
    default:
        return DefWindowProc(hWnd, message, wParam, lParam);
    }
    return 0;
}

LRESULT CALLBACK WndProcPaddle(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    static int x = 0;
    switch (message)
    {
    case WM_COMMAND:
    {
        int wmId = LOWORD(wParam);
        // Parse the menu selections:
        switch (wmId)
        {
        case IDM_ABOUT:
            DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
            break;
        case IDM_EXIT:
            DestroyWindow(hWnd);
            break;
        default:
            return DefWindowProc(hWnd, message, wParam, lParam);
        }
    }
    break;
    case WM_CREATE:
    {
        SetTimer(hWnd, 7, 5, NULL);
    }
    break;
    case WM_TIMER:
    {
        if (wParam == 7)
        {
            RECT rc, client;
            GetWindowRect(GetParent(hWnd), &rc);
            GetClientRect(GetParent(hWnd), &client);
            POINT pt;
            GetCursorPos(&pt);

            if (rc.left + 40<= pt.x && pt.x <= rc.right - 53)
                    MoveWindow(hWnd, paddleX = (pt.x - rc.left - 40), 220, 80, 20, true);
            else if (pt.x < rc.left + 40)
                MoveWindow(hWnd, paddleX = 0, 220, 80, 20, true);
            else if (pt.x > rc.right - 40)
                MoveWindow(hWnd, paddleX = client.right - 80, 220, 80, 20, true);

            //RECT client, parent;
            //GetClientRect(GetParent(hWnd), &client);
            //GetWindowRect(GetParent(hWnd), &parent);
            //POINT point;
            //GetCursorPos(&point);
            //int screenX = GetSystemMetrics(SM_CXSCREEN) / 2;

            //if (x + client.left >= client.left && client.right - x <= client.right)
            //{
            //    if (point.x < screenX)
            //        MoveWindow(hWnd, x -= , 220, 80, 20, true);
            //}
        }
    }
    break;
    case WM_PAINT:
    {
        PAINTSTRUCT ps;
        HDC hdc = BeginPaint(hWnd, &ps);
        // TODO: Add any drawing code that uses hdc here...

        EndPaint(hWnd, &ps);
    }
    break;
    case WM_GETMINMAXINFO:
    {
        MINMAXINFO* minMaxInfo = (MINMAXINFO*)lParam;
        minMaxInfo->ptMaxSize.x = minMaxInfo->ptMaxTrackSize.x = 100;
        minMaxInfo->ptMaxSize.y = minMaxInfo->ptMaxTrackSize.y = 20;
        minMaxInfo->ptMinTrackSize.x = 100;
        minMaxInfo->ptMinTrackSize.y = 20;
    }
    break;
    case WM_DESTROY:
        PostQuitMessage(0);
        break;
    default:
        return DefWindowProc(hWnd, message, wParam, lParam);
    }
    return 0;
}

// Message handler for about box.
INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
    UNREFERENCED_PARAMETER(lParam);
    switch (message)
    {
    case WM_INITDIALOG:
        return (INT_PTR)TRUE;

    case WM_COMMAND:
        if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
        {
            EndDialog(hDlg, LOWORD(wParam));
            return (INT_PTR)TRUE;
        }
        break;
    }
    return (INT_PTR)FALSE;
}
