// tutorial1.cpp : Defines the entry point for the application.
//

#include "framework.h"
#include "tutorial1.h"

#define MAX_LOADSTRING 100

// Global Variables:
HINSTANCE hInst;                                // current instance
WCHAR szTitle[MAX_LOADSTRING];                  // The title bar text
WCHAR szWindowClass[MAX_LOADSTRING];            // the main window class name

// Forward declarations of functions included in this code module:
ATOM                MyRegisterClass(HINSTANCE hInstance);
BOOL                InitInstance(HINSTANCE, int);
LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK    About(HWND, UINT, WPARAM, LPARAM);
void GetTextInfoForKeyMsg(WPARAM wParam, const TCHAR* msgName,
    TCHAR* buf, int bufSize);

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
    LoadStringW(hInstance, IDC_TUTORIAL1, szWindowClass, MAX_LOADSTRING);
    MyRegisterClass(hInstance);

    // Perform application initialization:
    if (!InitInstance (hInstance, nCmdShow))
    {
        return FALSE;
    }

    HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_TUTORIAL1));

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
    wcex.hIcon          = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_TUTORIAL1));
    wcex.hCursor        = LoadCursor(nullptr, IDC_ARROW);
    wcex.hbrBackground  = (HBRUSH)(COLOR_WINDOW+1);
    wcex.lpszMenuName   = MAKEINTRESOURCEW(IDC_TUTORIAL1);
    wcex.lpszClassName  = szWindowClass;
    wcex.hIconSm        = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

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

   //SetWindowLong(hWnd, GWL_EXSTYLE, GetWindowLong(hWnd, GWL_EXSTYLE) | WS_EX_LAYERED);
   //SetLayeredWindowAttributes(hWnd, 0, (255 * 50) / 100, LWA_ALPHA);

   ShowWindow(hWnd, nCmdShow);
   UpdateWindow(hWnd);

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
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    const int bufSize = 256;
    TCHAR buf[bufSize];
    static HCURSOR cursor = NULL;
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
            /*RECT rc;
            GetWindowRect(hWnd, &rc);
            OffsetRect(&rc, 20, 0);
            MoveWindow(hWnd, rc.left, rc.top, rc.right - rc.left, rc.bottom - rc.top, TRUE);*/
        }
        break;

    case WM_PAINT:
        {
            //PAINTSTRUCT ps;
            //HDC hdc = BeginPaint(hWnd, &ps);
            //// TODO: Add any drawing code that uses hdc here...
            //EndPaint(hWnd, &ps);

            //1
            //PAINTSTRUCT ps;
            //HDC hdc = BeginPaint(hWnd, &ps);
            //TCHAR s[] = _T(" Hello world !");
            //TextOut(hdc, 0, 0, s, (int)_tcslen(s));
            //EndPaint(hWnd, &ps);

            //2
            //PAINTSTRUCT ps;
            //HDC hdc = BeginPaint(hWnd, &ps);
            //TCHAR s[] = _T(" Hello world !");
            //RECT rc;
            //GetClientRect(hWnd, &rc);
            //DrawText(hdc, s, (int)_tcslen(s), &rc,
            //    DT_CENTER | DT_VCENTER | DT_SINGLELINE);
            //EndPaint(hWnd, &ps);

            //3
            PAINTSTRUCT ps;
            HDC hdc = BeginPaint(hWnd, &ps);
            HPEN pen = CreatePen(PS_SOLID, 2, RGB(255, 0, 0));
            HPEN oldPen = (HPEN)SelectObject(hdc, pen);
            MoveToEx(hdc, 0, 0, NULL);
            LineTo(hdc, 100, 100);
            SelectObject(hdc, oldPen);
            DeleteObject(pen);
            EndPaint(hWnd, &ps);

        }
        break;

    case WM_DESTROY:
        PostQuitMessage(0);
        break;

    case WM_GETMINMAXINFO:
    {
        int width, height;
        width = GetSystemMetrics(SM_CXSCREEN);
        height = GetSystemMetrics(SM_CYSCREEN);

        MINMAXINFO* minMaxInfo = (MINMAXINFO*)lParam;
        minMaxInfo->ptMaxSize.x = minMaxInfo->ptMaxTrackSize.x = width - 500;
        minMaxInfo->ptMaxSize.y = minMaxInfo->ptMaxTrackSize.y = height - 200;
    }
    break;

    case WM_SIZE:
    {
        int ClientWidth = LOWORD(lParam);
        int ClientHeight = HIWORD(lParam);

        RECT rc;
        GetWindowRect(hWnd, &rc);
        TCHAR s[256];
        _stprintf_s(s, 256, _T("Window's size: %d x %d Client area's size: %d x %d"), rc.right - rc.left, rc.bottom - rc.top, ClientWidth, ClientHeight);
        SetWindowText(hWnd, s);
    }
    break;

    /*case WM_CREATE:
    {
        cursor = LoadCursor(NULL, IDC_HAND);
    }
    break;*/

    /*case WM_SETCURSOR:
    {
        SetCursor(cursor);
    }
    break;*/

    /*case WM_NCHITTEST:
        return HTCAPTION;*/

    case WM_KEYDOWN:
        GetTextInfoForKeyMsg(wParam, _T(" KEYDOWN "), buf, bufSize);
        SetWindowText(hWnd, buf);
        break;

    case WM_KEYUP:
        GetTextInfoForKeyMsg(wParam, _T(" KEYUP "), buf, bufSize);
        SetWindowText(hWnd, buf);
        break;

    case WM_CHAR:
        _stprintf_s(buf, bufSize, _T(" WM_CHAR : %c"), (TCHAR)wParam);
        SetWindowText(hWnd, buf);
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

void GetTextInfoForKeyMsg(WPARAM wParam, const TCHAR* msgName,
TCHAR * buf, int bufSize)
{
    static int counter = 0;
    counter++;
    _stprintf_s(buf, bufSize, _T("%s key: %d ( counter : %d)"), msgName,
        wParam, counter);
}