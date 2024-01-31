// service-worker.js

self.addEventListener('install', (event) => {
    event.waitUntil(
        caches.open('your-cache-name').then((cache) => {
            return cache.addAll([
                //'index.html',
                //'css/style2.css',
                // Add other assets you want to cache here
            ]);
        })
    );
});

self.addEventListener('fetch', (event) => {
    event.respondWith(
        caches.match(event.request).then((response) => {
            return response || fetch(event.request);
        })
    );
});
